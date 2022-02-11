/*
  Code for Bubble, Bubble, Toil and Trouble

  Read serial for Unity to read game.

  Marjorie Ann Cuerdo
*/

// component IDs
const int PotID = 0;
const int PiezoID = 1;
const int UltraID = 2;

// The trigger pin to send our ultrasonic sound waves out on
int triggerPin = 7;
// The echo pin to read the return of the ultrasonic sound waves
int echoPin = 6;

// The piezo analog pin to read values from
int analogInputPinPiezo = 5;

// the max piezo value
int maxValuePiezo = 0;

// the min piezo value
int minValuePiezo = 1023;

// the previous piezo value
int lastPiezoValue = 0;

// The flex analog pin to read values from
int analogInputPinPot = 0;

// the max piezo value
int maxValuePot = 0;

// the min piezo value
int minValuePot = 1023;

// the previous piezo value
int lastPotValue = 0;

// The speed of sound in cm/µs
float speedOfSound = .034;

// Min value for ultrasonic sensor
int maxPlayerDistance = 20;

void setup() {
  // Setup serial communication with a baud rate of 9600
  Serial.begin(9600);

  // Sets the triggerPin as OUTPUT since we will be turning this on to send out ultrasonic waves
  pinMode(triggerPin, OUTPUT);
  
  // Sets the echoPin as an INPUT since we will be reading this to determine the round trip duration of those waves
  pinMode(echoPin, INPUT);
  
  delay(100);
}

  // COMM PROTOCOL
  // send a sensor value/state only when it has changed
  // we will send the sensor ID and new value/state in a single string line delimited by ','
  // the sensor IDs will be :
  //    PotID = 0
  //    PiezoID = 1 
  //    UltraID = 2
  
void loop() {

  // Read and store the FLEX analog value on analog pin analogInputPin
  float analogValuePot = analogRead(analogInputPinPot);

  maxValuePot = max(analogValuePot, maxValuePot);
  minValuePot = min(analogValuePot, minValuePot);
  
  // mapped analog value to (0 - 255)
  analogValuePot = (map(analogValuePot, minValuePot, maxValuePot, 0, 200) / 100.0);

  // see if the value of the piezo has changed from last time
  if(analogValuePot != lastPotValue) {
    // send the new value because it has changed

    // FORMAT: Pot ID 0, PotValue
    Serial.println(String(PotID) + "," + String(analogValuePot));
  }

  // we're done with the current analog value, store it as the last value now
  lastPotValue = analogValuePot;


  
  // Read and store the PIEZO analog value on analog pin analogInputPin
  int analogValuePiezo = analogRead(analogInputPinPiezo);

  maxValuePiezo = max(analogValuePiezo, maxValuePiezo);
  minValuePiezo = min(analogValuePiezo, minValuePiezo);

  // mapped analog value to (0 - 255)
  //analogValuePiezo = map(analogValuePiezo, minValuePiezo, maxValuePiezo, 0, 100);

  // see if the value of the piezo has changed from last time
  if(analogValuePiezo != lastPiezoValue) {
    // send the new value because it has changed

    // FORMAT: PiezoID 1, PiezoValue
    Serial.println(String(PiezoID) + "," + String(analogValuePiezo));
  }

  // we're done with the current analog value, store it as the last value now
  lastPiezoValue = analogValuePiezo;

  Serial.flush();
  
  // Wait at least 10 ms before we start the next loop for the ADC to settle
  delay(200);

  // Ultrasonic sensor
  
  // First, make sure that triggerPin is clear so set that pin on a LOW State for 2 µs
  digitalWrite(triggerPin, LOW);
  delayMicroseconds(2);
  
  // Now send an ultrasonic sound on the triggerPin for 10 µs
  digitalWrite(triggerPin, HIGH);
  delayMicroseconds(10);
  
  // Turn the triggerPin off now that we are done sending the sound
  digitalWrite(triggerPin, LOW);
  
  // Now read the echoPin, which will return the sound wave travel time in microseconds (round trip!)
  long duration = pulseIn(echoPin, HIGH);
  
  // Calculate the distance using the duration that the sound wave travelled round trip multiplied by the distance that sound will travel in a microsecond
  // Remember that the distance is one way so we need to divide our result by 2 (or multiply by .5)
  int distance = duration * speedOfSound / 2;

  // only print to serial when minValue has changed
  if (distance < maxPlayerDistance) {
    // Display our calculated distance on the Serial Monitor
    Serial.println(String(UltraID) + "," + String(distance));
  }
  
  // Add a slight delay to make the values easier to read
  delay(10);
}
