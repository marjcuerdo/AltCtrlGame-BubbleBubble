using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Challenges : MonoBehaviour
{

	public int damage = 1;
	int exercise = 5;
	int eatFood = 10;
	int social = 5;
	int earnMoney = 20;
	int covidDamage = 10;
	int covidHeal = 3; 

	public float speed = 1;

	public bool canDestroy = false;

	//public bool canCollect = false;

	public GameObject playerObj;

	void Start() {
		playerObj = GameObject.FindGameObjectWithTag("Player");
	}

	private void Update() {

		// continously move challenge bubbles left
		transform.Translate(Vector2.left * speed * Time.deltaTime);

		// if piezo was hit
		if (playerObj.GetComponent<SerialReaderPlayer>().canCollect) {
			StartCoroutine("StayTrue");
		}
	}

	// wait for half a second if piezo was hit then reset to false
	IEnumerator StayTrue() {
		
		Debug.Log("waiting...");
		yield return new WaitForSeconds(0.5f);
		playerObj.GetComponent<SerialReaderPlayer>().canCollect = false;

	}

	void OnTriggerStay2D(Collider2D col) {

		// destroy challenge bubbles when they leave the screen
		if (col.CompareTag("Border")) {
			//Debug.Log("destroying objects");
			Destroy(this.gameObject);
		}

		// check for what challenge bubbles have collided with player
		if (col.CompareTag("Player")) {

			// adjust player stats according to what bubble they contact
			if (transform.name == "ExerciseRisk") {
				if (playerObj.GetComponent<SerialReaderPlayer>().canCollect) {
						Debug.Log("Collecting need");
						col.GetComponent<Player>().physicalHealth += exercise;
						col.GetComponent<Player>().personalCovidLvl += covidDamage;
						col.GetComponent<Player>().communityCovidLvl += covidDamage;
						playerObj.GetComponent<SerialReaderPlayer>().noMask = true;
				}
			}

			if (transform.name == "ExerciseSafe(Clone)") {
					if (playerObj.GetComponent<SerialReaderPlayer>().canCollect) {
						Debug.Log("Collecting need");
						col.GetComponent<Player>().physicalHealth += exercise;
						col.GetComponent<Player>().personalCovidLvl -= covidHeal;
						col.GetComponent<Player>().communityCovidLvl -= covidHeal;
						playerObj.GetComponent<SerialReaderPlayer>().noMask = false;
					}
			}

			if (transform.name == "FoodSafe") {
					if (playerObj.GetComponent<SerialReaderPlayer>().canCollect) {
						Debug.Log("Collecting need");
						col.GetComponent<Player>().physicalHealth += eatFood;
						col.GetComponent<Player>().personalCovidLvl -= covidHeal;
						col.GetComponent<Player>().communityCovidLvl -= covidHeal;
						playerObj.GetComponent<SerialReaderPlayer>().noMask = false;
					}
			}

			if (transform.name == "FoodRisk") {
					if (playerObj.GetComponent<SerialReaderPlayer>().canCollect) {
						Debug.Log("Collecting need");
						col.GetComponent<Player>().physicalHealth += eatFood;
						col.GetComponent<Player>().personalCovidLvl += covidDamage;
						col.GetComponent<Player>().communityCovidLvl += covidDamage;
						playerObj.GetComponent<SerialReaderPlayer>().noMask = true;
					}
			}			

			if (transform.name == "SocialSafe") {
					if (playerObj.GetComponent<SerialReaderPlayer>().canCollect) {
						Debug.Log("Collecting need");
						col.GetComponent<Player>().mentalHealth += social;
						col.GetComponent<Player>().personalCovidLvl -= covidHeal;
						col.GetComponent<Player>().communityCovidLvl -= covidHeal;
						playerObj.GetComponent<SerialReaderPlayer>().noMask = false;
					}
			}	


			if (transform.name == "SocialRisk") {
					if (playerObj.GetComponent<SerialReaderPlayer>().canCollect) {
						Debug.Log("Collecting need");
						col.GetComponent<Player>().mentalHealth += social;
						col.GetComponent<Player>().personalCovidLvl += covidDamage;
						col.GetComponent<Player>().communityCovidLvl += covidDamage;
						playerObj.GetComponent<SerialReaderPlayer>().noMask = true;
					}
			}	

			if (transform.name == "MoneySafe") {
					if (playerObj.GetComponent<SerialReaderPlayer>().canCollect) {
						Debug.Log("Collecting need");
						col.GetComponent<Player>().financeHealth += earnMoney;
						col.GetComponent<Player>().personalCovidLvl -= covidHeal;
						col.GetComponent<Player>().communityCovidLvl -= covidHeal;
						playerObj.GetComponent<SerialReaderPlayer>().noMask = false;
					}
			}	

			if (transform.name == "MoneyRisk") {
					if (playerObj.GetComponent<SerialReaderPlayer>().canCollect) {
						Debug.Log("Collecting need");
						col.GetComponent<Player>().financeHealth += earnMoney;
						col.GetComponent<Player>().personalCovidLvl += covidDamage;
						col.GetComponent<Player>().communityCovidLvl += covidDamage;
						playerObj.GetComponent<SerialReaderPlayer>().noMask = true;
					}
			}			

			if (playerObj.GetComponent<SerialReaderPlayer>().canCollect) {
				Destroy(gameObject);
			}
		}

	}
}
