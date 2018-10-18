using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterLoadLevel : MonoBehaviour {

    public string scene = "MainMenu";

    public bool setPlayerPrefs = false;
    public int lastLevelOpen = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(setPlayerPrefs)
        {
            if(PlayerPrefs.GetInt("levelOpen") < lastLevelOpen)
            {
                PlayerPrefs.SetInt("levelOpen", lastLevelOpen);
            }
        }
        SceneManager.LoadScene(scene);
    }
}
