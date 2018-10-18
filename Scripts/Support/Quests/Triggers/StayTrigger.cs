using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayTrigger : MonoBehaviour {

    [HideInInspector]
    public bool triggered = false;

    int cnt = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            triggered = true;
            cnt++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        cnt--;
        if (cnt == 0) triggered = false;
    }
}
