using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseChangeTrigger : MonoBehaviour {

    public enum RunDirection
    {
        Left = -1,
        Right = 1
    }

    public Phases changeOn = Phases.Normal;
    public RunDirection runDirection = RunDirection.Right;

    private PhaseController pc;
    private int cnt = 0;

    private void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PhaseController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") )
        {
            if (cnt == 0)
            {
                Debug.Log("SendedRequest");
                pc.SendRequestToChangePhase(changeOn);
            }
            cnt++;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        cnt--;
    }
}
