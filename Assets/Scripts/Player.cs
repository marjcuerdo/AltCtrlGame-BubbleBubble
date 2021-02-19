using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	public float physicalHealth = 100;
    public float mentalHealth = 100;
    public float financeHealth = 100;
    public float personalCovidLvl = 0;
    public float communityCovidLvl = 0;

    public float speedPhys = (float)0.05;

    // Update is called once per frame
    void Update()
    {
        // decrement 
        physicalHealth -= Time.deltaTime + Time.deltaTime; // decrement 
        mentalHealth -= Time.deltaTime + Time.deltaTime; // decrement 
        financeHealth -= Time.deltaTime + Time.deltaTime; // decrement 
        personalCovidLvl += Time.deltaTime; // decrement 
        communityCovidLvl += Time.deltaTime; // decrement 

        if (physicalHealth <= 0) {
            Debug.Log("Your physical health has failed.");
        }

        if (mentalHealth <= 0) {
            Debug.Log("Your mental health has failed.");
        }

        if (financeHealth <= 0) {
            Debug.Log("Your financial health failed.");
        }

        if (personalCovidLvl >= 100) {
            Debug.Log("You got COVID-19.");
        }

        if (communityCovidLvl >= 100) {
            Debug.Log("The COVID-19 levels in your community are disastrous.");
        }      
    }

}
