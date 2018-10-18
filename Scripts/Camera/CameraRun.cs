using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRun : CameraFollowType
{
    private CameraFollow.RunPhaseFollow attrs;
    
    public CameraRun(CameraFollow _cf) : base(_cf)
    {
        attrs = cf.runAttributes;
    }

    public override Vector3 GetFinalPosition()
    {
        return new Vector3(cf.target.position.x + attrs.maxDistanceFromMid, cf.target.position.y + attrs.offset.y, cf.transform.position.z);
    }

    public override void Update()
    {
        float xPos = cf.transform.position.x;

        float tmp = cf.transform.position.x - cf.target.position.x;
        if (attrs.maxDistanceFromMid > tmp)
        {
            xPos = cf.target.position.x + attrs.maxDistanceFromMid;
        }
        float yLerp = Mathf.Lerp(cf.transform.position.y, cf.target.position.y + attrs.offset.y, attrs.smoothSpeed);
        cf.transform.position = new Vector3(xPos+attrs.xStep, yLerp, cf.transform.position.z);
    }
}
