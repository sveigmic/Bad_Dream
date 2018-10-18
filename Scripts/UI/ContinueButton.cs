using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour {

	public void ContinueAction()
    {
        StartCoroutine(CheckPointMaster.Instance().LoadCheckPoint());
    }

    private void OnEnable()
    {
        if (CheckPointMaster.Instance() == null) return;
        if (CheckPointMaster.Instance().ExistCheckPoint()) GetComponent<Button>().interactable = true;
        else GetComponent<Button>().interactable = false;
    }
}
