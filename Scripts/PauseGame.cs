﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {

    public bool paused = false;

	void Update () {
        if (paused) Time.timeScale = 0;
        else Time.timeScale = 1;
	}
}
