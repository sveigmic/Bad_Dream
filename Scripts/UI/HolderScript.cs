using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HolderScript : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {

    public float timeSlow = 0.5f;

    private bool slowNow = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        slowNow = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        slowNow = false;
    }

    private void Update()
    {
        if(slowNow)
        {
            Time.timeScale = timeSlow;
        } else
        {
            Time.timeScale = 1f;
        }
    }
}
