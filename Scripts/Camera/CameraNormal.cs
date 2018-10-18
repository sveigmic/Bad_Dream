using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraNormal : CameraFollowType {

    private CameraFollow.NormalPhaseFollow attrs;

    public CameraNormal(CameraFollow _cf) : base(_cf)
    {
        attrs = cf.normalAttributes;
    }

    public override Vector3 GetFinalPosition()
    {
        return cf.target.position + attrs.offset;
    }

    public override void Update()
    {
        Vector3 desiredPostion = GetFinalPosition();
        Vector3 smoothedPosition = Vector3.Lerp(cf.transform.position, desiredPostion, attrs.smoothSpeed);
        cf.transform.position = smoothedPosition;
    }
}
