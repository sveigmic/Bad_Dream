using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {

    public List<Vector3> localWaypoints;

    public LayerMask layer;
    public float speed = 1;
    public float waitTime = 0;
    public bool cyclic = false;

    [Range(0,2)]
    public float easeCoeficient = 0;

    private float lastTime = 0;
    private int fromIndex = 0;
    private int toIndex = 1;
    private float perc = 0;

    private Rigidbody2D rb;

    private Collider2D coll;
    private Vector3 tr = Vector3.zero;

    private void Start()
    {
        coll = GetComponent<Collider2D>();
        rb = transform.GetComponent<Rigidbody2D>();
        lastTime = 0;
    }
    private void FixedUpdate()
    {
        CalcNextPos();
    }

    private void CalcNextPos()
    {
        if(Time.time < lastTime + waitTime)
        {
            fromIndex = fromIndex % localWaypoints.Count;
            rb.velocity = (localWaypoints[fromIndex] - transform.position)*speed;
            return;
        }
        fromIndex = fromIndex % localWaypoints.Count;
        toIndex = (fromIndex + 1) % localWaypoints.Count;
        float dist = Vector3.Distance(localWaypoints[fromIndex], localWaypoints[toIndex]);
        perc += Time.deltaTime * speed / dist;
        perc = Mathf.Clamp01(perc);
        float eased = Ease(perc);

        Vector3 newPos = Vector3.Lerp(localWaypoints[fromIndex], localWaypoints[toIndex], eased);

        if(perc >= 1f)
        {
            perc = 0;
            fromIndex++;
            
            if(!cyclic)
            {
                if(fromIndex >= localWaypoints.Count - 1)
                {
                    fromIndex = 0;
                    localWaypoints.Reverse();
                }
            }
            lastTime = Time.time;
        }
        rb.velocity = (newPos - transform.position) * speed;
    }

    private List<Transform> GetPassangers()
    {
        List<Transform> pass = new List<Transform>();
        Vector2 rayStart = coll.bounds.center + new Vector3(0, 3 * coll.bounds.size.y / 4, 0);
        Vector2 size = new Vector2(coll.bounds.size.x, coll.bounds.size.y / 2);
        RaycastHit2D[] hits = Physics2D.BoxCastAll(rayStart, size, 0, Vector2.down, 0f, layer.value);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit)
            {
                pass.Add(hit.collider.transform);
            }
        }
        return pass;
    }

    private float Ease(float x)
    {
        float a = easeCoeficient + 1;
        return Mathf.Pow(x, a) / (Mathf.Pow(x, a) + Mathf.Pow(1 - x, a));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;
        foreach (Vector3 x in localWaypoints)
        {
            Gizmos.DrawSphere(x, 1f);
        }
    }
}
