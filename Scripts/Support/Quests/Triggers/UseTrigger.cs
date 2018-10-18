using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseTrigger : MonoBehaviour {

    TouchManager t;

    [HideInInspector]
    public bool complete = false;

    public GameObject box;
    
    private void Start()
    {
        t = GameObject.Find("Player").GetComponent<PhaseController>().touchManager;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(t.AreaSwipeUp || Input.GetKeyDown(KeyCode.K))
            {
                GetComponent<Animator>().SetTrigger("down");
                complete = true;
                box.SetActive(true);
            }
        }
    }

}
