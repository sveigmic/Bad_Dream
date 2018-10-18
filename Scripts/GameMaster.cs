﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {

    public Camera newCam;

    public Canvas levelSelect;
    public Canvas reportCanvas;

    private Camera oldCam;

    public ButtonEvents play;
    public ButtonEvents options;
    public ButtonEvents credits;
    public ButtonEvents report;
    public ButtonEvents exit;

    private void Start()
    {
        newCam.gameObject.SetActive(false);
        levelSelect.gameObject.SetActive(false);
        reportCanvas.gameObject.SetActive(false);

    }

    public void QuitApp()
    {
        Application.Quit();
    }

    public void PlayEvent()
    {
        oldCam = Camera.main;
        ActiveMainMenuButtons(false);
        oldCam.gameObject.SetActive(false);
        newCam.gameObject.SetActive(true);
        newCam.GetComponent<Animator>().Play("MoveToBed");

    }

    public void ActiveMainMenuButtons(bool isActive)
    {
        play.SetActive(isActive);
        options.SetActive(isActive);
        credits.SetActive(isActive);
        report.SetActive(isActive);
        exit.SetActive(isActive);
    }

    public void ActivateLevelUI(bool isActiv)
    {
        levelSelect.gameObject.SetActive(isActiv);
    }

    public void ActivateMainMenu()
    {
        ActivateLevelUI(false);
        ActiveMainMenuButtons(true);
        newCam.gameObject.SetActive(false);
        oldCam.gameObject.SetActive(true);
    }

    public void ReportOpen()
    {
        ActiveMainMenuButtons(false);
        reportCanvas.gameObject.SetActive(true);
        HelpCanvas hc = reportCanvas.GetComponent<HelpCanvas>();
        hc.ResetInputFields();
        hc.mainPanel.gameObject.SetActive(true);
    }

    public void ReportClose ()
    {
        ActiveMainMenuButtons(true);
        reportCanvas.gameObject.SetActive(false);
    }

    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void DebugLog(string log)
    {
        Debug.Log(log);
    }
}
