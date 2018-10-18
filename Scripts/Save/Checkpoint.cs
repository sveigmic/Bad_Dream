using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    Animator anim;
    bool active = false;
    
	void Start () {
        anim = GetComponent<Animator>();
        anim.enabled = false;
        
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !active)
        {
            active = true;
            anim.enabled = true;
            CheckPointMaster.Instance().AddCheckPoint(this);
            GetComponent<BoxCollider2D>().enabled = false;

            GetComponent<Checkpoint>().enabled = false;
        }
    }
}
