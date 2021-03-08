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

    public bool maskProtection = false;

    // Update is called once per frame
    void Update()
    {
        // if there's NO mask protection 
        if (!maskProtection) {
            // decrement 
            physicalHealth -= Time.deltaTime + 0.017f; // decrement 
            mentalHealth -= Time.deltaTime + 0.015f; // decrement 
            financeHealth -= Time.deltaTime + 0.010f; // decrement 
            personalCovidLvl += Time.deltaTime + 0.010f; // decrement 
            communityCovidLvl += Time.deltaTime + 0.02f; // decrement 
        } 
        // if there IS mask protection
        else {
            physicalHealth -= Time.deltaTime; // decrement 
            mentalHealth -= Time.deltaTime; // decrement 
            financeHealth -= Time.deltaTime; // decrement 
            personalCovidLvl += Time.deltaTime; // decrement 
            communityCovidLvl += Time.deltaTime; // decrement 
        }



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
