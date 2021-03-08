/**
 * Using Ardity to read serial from Arduino to control the game.
 * Marjorie Ann Cuerdo
 * 
 * Ardity (Serial Communication for Arduino + Unity)
 * Author: Daniel Wilches <dwilches@gmail.com>
 *
 * This work is released under the Creative Commons Attributions license.
 * https://creativecommons.org/licenses/by/2.0/
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
//using Serial;

//Serial arduinoPort;


/**
 * When creating your message listeners you need to implement these two methods:
 *  - OnMessageArrived
 *  - OnConnectionEvent
 */
public class SerialReaderPlayer : MonoBehaviour
{

// piezo value
float piezoValue = 0;

// pot value
float potValue = 0;

// ultrasonic value
float ultSonValue = 0;

public SpriteRenderer bubbleObj;
public SpriteRenderer maskObj;

//public GameObject challengeObj;

public bool canCollect = false;
public float maskTimer = 5;

public bool noMask = false;

public int colCount = 0;

public Player playerObj;

public AudioSource coughAudio;
public AudioSource bubbleAudio;

	void Start() {

		bubbleObj = GameObject.Find("bubble").GetComponent<SpriteRenderer>();
		maskObj = GameObject.Find("mask_shirt").GetComponent<SpriteRenderer>();
		playerObj = GameObject.Find("bubble").GetComponent<Player>();
	}

	void Update() {
        if (maskTimer >= 0) {
            //Debug.Log("timer: " + maskTimer);
            maskTimer -= Time.deltaTime;
        }

        if (maskTimer <= 0) {
            maskObj.enabled = false;
            playerObj.maskProtection = false;
            noMask = true;
        } else {
            playerObj.maskProtection = true;
            maskObj.enabled = true;
            coughAudio.Play();
        }
	}

    public void EnableSpriteRender() {
        maskObj.enabled = true;
    }

	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag("Challenge")) {
			colCount++;
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.CompareTag("Challenge")) {
			colCount--;
		}
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

        		// potentiometer
        		if (float.Parse(compValues[0].Trim()) == 0) {
	        		potValue = float.Parse(compValues[1].Trim());

	        		// turn pot to control size of bubble
	        		bubbleObj.transform.localScale = new Vector3(potValue, potValue, 1f);

        		}  
        		// piezo buzzer
        		else if (float.Parse(compValues[0].Trim()) == 1) {
        			piezoValue = float.Parse(compValues[1].Trim());

        			// hit piezo to temporarily enable collecting objects
	        		if (piezoValue > 50) {
	        			canCollect = true;
                        bubbleAudio.Play();
	        			//Debug.Log("Piezo was hit");
	        		}
        		}

                // ultrasonic sensor
                else if (float.Parse(compValues[0].Trim()) == 2) {
                    ultSonValue = float.Parse(compValues[1].Trim());

                    Debug.Log(ultSonValue);

                    if (ultSonValue < 20) {
                        //noMask = false;
                        // reset mask
                        noMask = false;
                        //maskObj.enabled = true;
                        maskTimer = 5;
                    }

                }
        	}
        }

    }

    // Invoked when a connect/disconnect event occurs. The parameter 'success'
    // will be 'true' upon connection, and 'false' upon disconnection or
    // failure to connect.
    void OnConnectionEvent(bool success)
    {
        /*if (success)
            Debug.Log("Connection established");
        else
            Debug.Log("Connection attempt failed or disconnection detected");*/
    }
}
