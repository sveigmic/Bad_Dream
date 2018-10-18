using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public LayerMask layer;
    HashSet<Transform> movedTrans;
    Vector3 lastPos = Vector2.zero;

    Collider2D coll;
    private void Start()
    {
        movedTrans = new HashSet<Transform>();
        coll = GetComponent<Collider2D>();
        lastPos = transform.position;
    }

    private void Update()
    {
        Vector2 rayStart = coll.bounds.center + new Vector3(0,3*coll.bounds.size.y/4,0);
        Vector2 size = new Vector2(coll.bounds.size.x, coll.bounds.size.y / 2);
        RaycastHit2D[] hits = Physics2D.BoxCastAll(rayStart, size, 0, Vector2.down, 0f, layer.value);
        foreach(RaycastHit2D hit in hits)
        {
            if(hit)
            {
                hit.collider.transform.Translate(transform.position - lastPos);
            }
        }
        lastPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (layer == (layer | (1 << collision.gameObject.layer)))
        {
            //collision.transform.parent = transform.parent;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (layer == (layer | (1 << collision.gameObject.layer)))
        {
            //collision.transform.parent = null;
        }
    }
}
