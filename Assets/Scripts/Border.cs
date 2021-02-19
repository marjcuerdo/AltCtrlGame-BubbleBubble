using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{

	// destroy challenge bubbles when they reach end of screen
	void OnTriggerEnter2D(Collider2D col) {

		if (col.CompareTag("Challenge")) {
			//Debug.Log("destroying objects");
			Destroy(gameObject);
		}
	}
}
