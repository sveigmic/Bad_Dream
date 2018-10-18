using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowType {

    protected CameraFollow cf;

    public CameraFollowType(CameraFollow _cf)
    {
        cf = _cf;
    }

    public virtual void Update()
    {

    }

    public virtual Vector3 GetFinalPosition()
    {
        return Vector3.zero;
    }

}
