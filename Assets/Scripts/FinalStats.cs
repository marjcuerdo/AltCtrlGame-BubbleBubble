using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalStats : MonoBehaviour
{
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI physText;
   	public TextMeshProUGUI mentText;
    public TextMeshProUGUI finText;
    public TextMeshProUGUI yourVirText;
    public TextMeshProUGUI cityVirText;
    

    // Start is called before the first frame update
    void Start()
    {
        physText.text = "Physical Health: " + PlayerPrefs.GetFloat("Physical").ToString();
        mentText.text = "Mental Health: " + PlayerPrefs.GetFloat("Mental").ToString();
        finText.text = "Finances: " + PlayerPrefs.GetFloat("Finances").ToString();
        yourVirText.text = "Your Virus %: " + PlayerPrefs.GetFloat("Your Virus").ToString();
        cityVirText.text = "City Virus %: " + PlayerPrefs.GetFloat("City Virus").ToString();

        float worstStat = 0;
        float index = 0;

        float[] statArray = {PlayerPrefs.GetFloat("Physical"), PlayerPrefs.GetFloat("Mental"), PlayerPrefs.GetFloat("Finances"), PlayerPrefs.GetFloat("Your Virus"), PlayerPrefs.GetFloat("City Virus")};

        for (int i=0; i < statArray.Length; i++) {
            if (i <= 2) {
                if (statArray[i] < worstStat) {
                    worstStat = statArray[i];
                    index = i;
                }
            } else {
                if (statArray[i] >= 100) {
                    worstStat = statArray[i];
                    index = i;
                }
            }
        }

        if (index == 0) {
            resultText.text = "Your physical health has failed.";
        } else if (index == 1) {
            resultText.text = "Your mental health has failed.";
        } else if (index == 2) {
            resultText.text = "Your finances have failed.";
        } else if (index == 3) {
            resultText.text = "You got COVID-19. You should probably get tested and contact anyone you've seen lately...";
        } else if (index == 4) {
            resultText.text = "Your city's COVID-19 levels are too high. A stay-at-home order is now in place.";
        } 

        // change text color depending on level
        CheckStatus(PlayerPrefs.GetFloat("Physical").ToString(), physText);
        CheckStatus(PlayerPrefs.GetFloat("Mental").ToString(), mentText);
        CheckStatus(PlayerPrefs.GetFloat("Finances").ToString(), finText);
        CheckStatus(PlayerPrefs.GetFloat("Your Virus").ToString(), yourVirText);
        CheckStatus(PlayerPrefs.GetFloat("City Virus").ToString(), cityVirText);
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