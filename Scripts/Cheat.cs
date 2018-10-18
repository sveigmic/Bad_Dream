using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheat : MonoBehaviour {
    int act = 0;
	
	void Update () {
        if (act > 9)
        {
            PlayerPrefs.SetInt("levelOpen", 10);
            SceneManager.LoadScene("FactoryPre");
        }
	}

    public void AddClick()
    {
        act++;
    }
}
