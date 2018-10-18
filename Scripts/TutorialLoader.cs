using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TutorialLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("FirstStart"))
        {
            if (PlayerPrefs.GetInt("FirstStart") == 1)
            {
                SceneManager.LoadScene("MainMenu");
                return;
            }
        }
        PlayerPrefs.SetInt("FirstStart", 1);
        SceneManager.LoadScene("Movement");
    }
}
