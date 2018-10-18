using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadFog : MonoBehaviour {

    public Transform cam;

    public Vector2 offset;

    private Animator anim;
	
	void Awake () {
        anim = GetComponent<Animator>();
        gameObject.SetActive(false);	
	}
	
	
	void Update () {
        transform.position = new Vector3(cam.position.x - offset.x, cam.position.y - offset.y, transform.position.z);
	}

    public void SpawnFog()
    {
        gameObject.SetActive(true);
        anim.Play("Spawn");
    }

    public void HideFog()
    {
        anim.Play("Despawn");
    }

    public void DeactivateObject()
    {
        gameObject.SetActive(false);
    }
}
