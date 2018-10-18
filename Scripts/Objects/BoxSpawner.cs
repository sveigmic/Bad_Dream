using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour {

    public int boxCount = 3;
    public GameObject prefab;
    public Transform spawnPoint;

    public bool reseting = false;
    public float resetDepth = 0;

    private float lastTime = 0;

    private GameObject[] boxes;

	// Use this for initialization
	void Start () {
        boxes = new GameObject[3];
        for(int i = 0; i<boxCount;i++)
        {
            boxes[i] = Instantiate(prefab);
            boxes[i].SetActive(false);
            boxes[i].transform.position = spawnPoint.position;
        }
	}

    private void Update()
    {
        for (int i = 0; i < boxCount; i++)
        {
            if (boxes[i].transform.position.y < resetDepth)
            {
                boxes[i].transform.rotation = new Quaternion(0, 0, 0, 0);
                boxes[i].gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (collision.GetComponent<PhaseController>().touchManager.AreaSwipeUp || Input.GetKeyDown(KeyCode.K))
            {
                if (Time.time - lastTime > 1f)
                {
                    lastTime = Time.time;
                    GetComponent<Animator>().SetTrigger("down");
                    SpawnBox();
                }
            }

        }  
    }

    private void SpawnBox()
    {
        for (int i = 0; i < boxCount; i++)
        {
            if(!boxes[i].gameObject.activeSelf)
            {
                boxes[i].transform.position = spawnPoint.transform.position;
                boxes[i].gameObject.SetActive(true);
                break;
            }
        }
    }

}
