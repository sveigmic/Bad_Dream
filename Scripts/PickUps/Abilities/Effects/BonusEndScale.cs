using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusEndScale : BonusEffect {


    public List<ParticleSystem> effectsToScale;
    public List<Vector3> effectsScales;
    private AbilityTrigger tr;

    public float scaleTime = 1f;
    private Vector3 endScale = Vector3.zero;

    private float startTime = 0;
    private Vector3 startScale = Vector3.zero;
    private Vector3 coef;

    void Start()
    {
        tr = GetComponent<AbilityTrigger>();
        foreach (ParticleSystem x in effectsToScale)
        {
            effectsScales.Add(x.transform.localScale);
        }
    }

    public override void Reset()
    {
        startTime = 0;
        if(startScale != Vector3.zero) transform.localScale = startScale;
        for (int i = 0; i<effectsScales.Count;i++)
        {
            effectsToScale[i].transform.localScale = effectsScales[i];
        }
    }

    void Update () {
		if(tr.WasPickedUp())
        {
            if (startTime == 0) {
                startTime = Time.time;
                startScale = transform.localScale;
            }
            float sc = (Time.time - startTime) / scaleTime;
            sc = 1 - sc;
            if (sc <= 0) sc = 0;
            transform.localScale = startScale * sc;
            for (int i = 0; i < effectsScales.Count; i++)
            {
                effectsToScale[i].transform.localScale = effectsScales[i] * sc;
            }
        }
    }
} 
