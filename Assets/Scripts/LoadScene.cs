using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

	Scene m_Scene;
	string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        m_Scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    public void GetScene()
    {
        if (m_Scene.name == "StartMenu") {
            SceneManager.LoadScene("Instructions");
        }  else if (m_Scene.name == "Instructions") {
            SceneManager.LoadScene("BubbleSocial");
        }
        else if (m_Scene.name == "FailureEnding") {
        	SceneManager.LoadScene("BubbleSocial");
        } else if (m_Scene.name == "SuccessEnding") {
        	SceneManager.LoadScene("BubbleSocial");
        }
    }
}
