using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [System.Serializable]
    public class NormalPhaseFollow
    {
        [Range(0f, 1f)]
        public float smoothSpeed = 0.125f;
        public Vector3 offset;
    }

    [System.Serializable]
    public class RunPhaseFollow
    {
        [Range(0f, 10f)]
        public float maxDistanceFromMid = 3f;
        [Range(0f, 0.5f)]
        public float xStep = 0.1f;
        [Range(0f, 1f)]
        public float smoothSpeed = 0.125f;
        public Vector3 offset;
    }

    public Transform target;
    public NormalPhaseFollow normalAttributes;
    public RunPhaseFollow runAttributes;

    [Header("Camera swap options")]
    [Range(0f, 5f)]
    public float swapTime = 1f;

    public Phases startCam = Phases.Normal;


    private bool swapping = false;

    private Vector3 startPos;
    private Vector3 endPos;
    private float timeStart;

    private CameraFollowType actFollow;



    void Start () {
        switch (startCam)
        {
            case Phases.Normal:
                actFollow = new CameraNormal(this);
                break;
            case Phases.Running:
                actFollow = new CameraRun(this);
                break;
            default:
                actFollow = new CameraNormal(this);
                break;
        }

	}

    public void FixedUpdate()
    {
        if (swapping)
        {
            float tmpTime = Time.time - timeStart;
            float compl = tmpTime / swapTime;
            endPos = actFollow.GetFinalPosition();
            transform.position = Vector3.Lerp(startPos, endPos, compl);
            if (compl >= 1.0f)
            {
                swapping = false;
            }
        } else
        {
            actFollow.Update();
        }
    }

    public void SwapCamera(Phases _ph)
    {
        switch(_ph)
        {
            case Phases.Normal:
                actFollow = new CameraNormal(this);
                break;
            case Phases.Running:
                actFollow = new CameraRun(this);
                break;
        }
        timeStart = Time.time;
        startPos = transform.position;
        swapping = true;
    }
}
