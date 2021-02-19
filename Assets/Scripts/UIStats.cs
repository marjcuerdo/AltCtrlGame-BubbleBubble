using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIStats : MonoBehaviour
{
    // health stats
    public TextMeshProUGUI physHealthText;
    public TextMeshProUGUI mentHealthText;
    public TextMeshProUGUI finHealthText;
    public TextMeshProUGUI yourCovidText;
    public TextMeshProUGUI commCovidText;

    // days stats
    //public TextMeshProUGUI daysText;

    // timers
    public float daysLeft = 90;
    public bool timerIsRunning = false;

    // access player stats
    public GameObject playerObj;

    // slider
    public Slider slider;

    private float currentValue = 0f;

	void Start() {
        timerIsRunning = true; // start timer
        playerObj = GameObject.Find("bubble");
        //playerObj = findChildFromParent(transform.name, "Player");
	}

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning) {
            daysLeft -= Time.deltaTime; // decrement 

            //daysText.text = "March 2020";

            currentValue = 90 - daysLeft;
            slider.value = currentValue;            


            if (playerObj.GetComponent<Player>().physicalHealth <= 0 || playerObj.GetComponent<Player>().mentalHealth <= 0 || playerObj.GetComponent<Player>().financeHealth <= 0 ) {
                PlayerPrefs.SetFloat("Physical", playerObj.GetComponent<Player>().physicalHealth);
                PlayerPrefs.SetFloat("Mental", playerObj.GetComponent<Player>().mentalHealth);
                PlayerPrefs.SetFloat("Finances", playerObj.GetComponent<Player>().financeHealth);
                PlayerPrefs.SetFloat("Your Virus", playerObj.GetComponent<Player>().personalCovidLvl);
                PlayerPrefs.SetFloat("City Virus", playerObj.GetComponent<Player>().communityCovidLvl); 
                SceneManager.LoadScene("FailureEnding");               
            } else if (playerObj.GetComponent<Player>().personalCovidLvl >= 100 || playerObj.GetComponent<Player>().communityCovidLvl >= 100) {
                PlayerPrefs.SetFloat("Physical", playerObj.GetComponent<Player>().physicalHealth);
                PlayerPrefs.SetFloat("Mental", playerObj.GetComponent<Player>().mentalHealth);
                PlayerPrefs.SetFloat("Finances", playerObj.GetComponent<Player>().financeHealth);
                PlayerPrefs.SetFloat("Your Virus", playerObj.GetComponent<Player>().personalCovidLvl);
                PlayerPrefs.SetFloat("City Virus", playerObj.GetComponent<Player>().communityCovidLvl);    
                SceneManager.LoadScene("FailureEnding");
            } else if (daysLeft <= 0) {
                Debug.Log("You made it to the end without dying");

                PlayerPrefs.SetFloat("Physical", playerObj.GetComponent<Player>().physicalHealth);
                PlayerPrefs.SetFloat("Mental", playerObj.GetComponent<Player>().mentalHealth);
                PlayerPrefs.SetFloat("Finances", playerObj.GetComponent<Player>().financeHealth);
                PlayerPrefs.SetFloat("Your Virus", playerObj.GetComponent<Player>().personalCovidLvl);
                PlayerPrefs.SetFloat("City Virus", playerObj.GetComponent<Player>().communityCovidLvl);

                SceneManager.LoadScene("SuccessEnding");
                // go to game over screen
            }

            physHealthText.text = "Physical: " + playerObj.GetComponent<Player>().physicalHealth.ToString();
            mentHealthText.text = "Mental: " + playerObj.GetComponent<Player>().mentalHealth.ToString();
            finHealthText.text = "Finances: " + playerObj.GetComponent<Player>().financeHealth.ToString();
            yourCovidText.text = "Your Virus %: " + playerObj.GetComponent<Player>().personalCovidLvl.ToString();
            commCovidText.text = "City Virus %: " + playerObj.GetComponent<Player>().communityCovidLvl.ToString();
        }

        // change text color depending on level
        CheckStatus(playerObj.GetComponent<Player>().physicalHealth.ToString(), physHealthText);
        CheckStatus(playerObj.GetComponent<Player>().mentalHealth.ToString(), mentHealthText);
        CheckStatus(playerObj.GetComponent<Player>().financeHealth.ToString(), finHealthText);
        CheckStatus(playerObj.GetComponent<Player>().personalCovidLvl.ToString(), yourCovidText);
        CheckStatus(playerObj.GetComponent<Player>().communityCovidLvl.ToString(), commCovidText);
    }

    void CheckStatus(string txt, TextMeshProUGUI tm) {

        if (!tm.text.Contains("Your Virus") && !tm.text.Contains("City Virus")) {
            if (float.Parse(txt) >= 65) {
                tm.color = new Color32(0, 153, 0, 255); // green
            } else if (float.Parse(txt) >= 45) {
                tm.color = new Color32(255, 153, 0, 255); // orange
            } else {
                tm.color = new Color32(128, 0, 0, 255); // red
            }
        } else {
            if (float.Parse(txt) >= 65) {
                tm.color = new Color32(128, 0, 0, 255); // red
            } else if (float.Parse(txt) >= 45) {
                tm.color = new Color32(255, 153, 0, 255); // orange
            } else if (float.Parse(txt) < 45) {
                tm.color = new Color32(0, 153, 0, 255); // green
            }          
        }
    }
}
