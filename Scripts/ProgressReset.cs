using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressReset : MonoBehaviour {

    public void ProgressRestart()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("levelOpen", 0);
    }
}