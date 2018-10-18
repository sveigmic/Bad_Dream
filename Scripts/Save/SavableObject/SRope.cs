using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRope : SavableObject {

    struct SegmentInfo
    {
        public Vector3 pos;
        public Quaternion rot;
        public Vector2 velocity;
    }

    private SegmentInfo[] segments;

    public override void Save()
    {
        int cnt = transform.childCount;
        segments = new SegmentInfo[cnt];
        for(int i = 0; i < cnt;i++)
        {
            Transform x = transform.GetChild(i);
            SegmentInfo s = new SegmentInfo();
            s.pos = x.position;
            s.rot = x.rotation;
            s.velocity = x.GetComponent<Rigidbody2D>().velocity;
            segments[i] = s;
        }
    }

    public override void Load()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform x = transform.GetChild(i);
            SegmentInfo s = segments[i];
            x.position = s.pos;
            x.rotation = s.rot;
            x.GetComponent<Rigidbody2D>().velocity = s.velocity;
        }
    }
}
