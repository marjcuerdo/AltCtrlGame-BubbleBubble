/**
 * Ardity (Serial Communication for Arduino + Unity)
 * Author: Daniel Wilches <dwilches@gmail.com>
 *
 * This work is released under the Creative Commons Attributions license.
 * https://creativecommons.org/licenses/by/2.0/
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
//using Serial;

//Serial arduinoPort;




/**
 * When creating your message listeners you need to implement these two methods:
 *  - OnMessageArrived
 *  - OnConnectionEvent
 */
public class SerialReader : MonoBehaviour
{

// piezo value
int piezoValue = 0;

// pot value
int potValue = 0;

public RawImage image;

	void Start() {
		//image.GetComponent<RawImage>().color = new Color32(255,255,225,100);
		image.GetComponent<RawImage>().color = Color.red;


	}

    // Invoked when a line of data is received from the serial device.
    void OnMessageArrived(string msg)
    {
        //Debug.Log("Message arrived: " + msg);

     // OUR COMMUNICATION PROTOCOL
    // Send all sensor values in a single string line delimited by ','
    // The sensor order in the string is ID,value 
    // Read a string line from serial

        if(msg != null) {
        	string[] compValues = msg.Split(',');
        	// make sure values weren't corrupted
        	if (compValues.Length == 2) {

        		if (int.Parse(compValues[0].Trim()) == 0) {
	        		potValue = int.Parse(compValues[1].Trim());
	        		//image.GetComponent<Image>().color = new Color32(255-(Convert.ToInt32(potValue)),255,225,100);
	        		//image.GetComponent<RawImage>().color = new Color32(17,9,233,100); // blue
	        		image.GetComponent<RawImage>().color = Color.blue;
	        		//Debug.Log("Pot: " + potValue.ToString());
	        		Debug.Log("Flex: " + potValue.ToString());
        		} else if (int.Parse(compValues[0].Trim()) == 1) {
        			piezoValue = int.Parse(compValues[1].Trim());
        			//image.GetComponent<RawImage>().color = new Color32(233,9,9,100); // red
        			image.GetComponent<RawImage>().color = Color.green;
	        		//Debug.Log("Piezo: " + potValue.ToString());
        		}
        	}
        }

    }

    // Invoked when a connect/disconnect event occurs. The parameter 'success'
    // will be 'true' upon connection, and 'false' upon disconnection or
    // failure to connect.
    void OnConnectionEvent(bool success)
    {
        if (success)
            Debug.Log("Connection established");
        else
            Debug.Log("Connection attempt failed or disconnection detected");
    }
}
