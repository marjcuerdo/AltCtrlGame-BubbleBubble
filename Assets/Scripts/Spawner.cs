using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spawn challenge bubbles in various positions
public class Spawner : MonoBehaviour
{
	public GameObject[] obstacleArr;

	private float timeBtwSpawn;
	public float startTimeBtwSpawn;
	public float decreaseTime;
	public float minTime = 0.65f;
	

	private void Update() { 

		// randomize y position of new spawn
		var position = new Vector3(transform.position.x, transform.position.y + Random.Range(-3f,3f), transform.position.z);

		// choose a random object
		int index = Random.Range(0,obstacleArr.Length);


		if (timeBtwSpawn <= 0) {
			Instantiate(obstacleArr[index], position, Quaternion.identity);
			timeBtwSpawn = startTimeBtwSpawn;
			if (startTimeBtwSpawn > minTime) {
				startTimeBtwSpawn -= decreaseTime; // respawn them faster
			}

		} else {
			timeBtwSpawn -= Time.deltaTime;
		}
	}
}
