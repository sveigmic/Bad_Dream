using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieTrigger : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PhaseController pc = collision.GetComponent<PhaseController>();
        if (pc != null)
        {
            pc.gameMaster.GameOverShow(true);
            gameObject.SetActive(false);
        }
    }
}
