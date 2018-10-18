using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMasterPhases : MonoBehaviour {

    public RectTransform mainUI;

    public RectTransform normalUI;
    public RectTransform runUI;
    public RectTransform pauseUI;
    public RectTransform gameOverUI;

    public TouchManager touchManager;
    
    private RectTransform actUI;

    public CameraFollow camFollow;

    public bool paused = false;

    private void Awake()
    {
        pauseUI.gameObject.SetActive(false);
        gameOverUI.gameObject.SetActive(false);
        PauseMenuOpen(false);
    }

    private void Update()
    {
        if (paused) Time.timeScale = 0;
        else Time.timeScale = 1;
    }

    public void ActivateCameraByPhase(Phases _phase)
    {
        camFollow.SwapCamera(_phase);
    }

    public void PauseMenuOpen(bool _open)
    {
        touchManager.gameObject.SetActive(!_open);
        if(actUI !=null) actUI.gameObject.SetActive(!_open);
        PauseGame(_open);
        pauseUI.gameObject.SetActive(_open);
    }

    public void PauseGame(bool pause)
    {
        paused = pause;
    }

    public void ActivateUIByPhase(Phases _phase)
    {
        switch(_phase)
        {
            case Phases.Normal:
                actUI = normalUI;
                normalUI.gameObject.SetActive(true);
                runUI.gameObject.SetActive(false);
                break;
            case Phases.Running:
                actUI = runUI;
                normalUI.gameObject.SetActive(false);
                runUI.gameObject.SetActive(true);
                break;
        }
    }

    public void LoadScene(string _scene)
    {
        paused = false;
        SceneManager.LoadScene(_scene);
    }

    public void GameOverShow(bool active)
    {
        mainUI.gameObject.SetActive(!active);
        gameOverUI.gameObject.SetActive(active);
        camFollow.enabled = !active;
        if (active) {
            gameOverUI.GetComponent<Animator>().Play("GameOver");
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
