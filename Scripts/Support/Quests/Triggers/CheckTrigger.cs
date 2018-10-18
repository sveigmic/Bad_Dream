using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTrigger : MonoBehaviour {

    public bool complete = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Box"))
        {
            complete = true;
        }
    }
}
