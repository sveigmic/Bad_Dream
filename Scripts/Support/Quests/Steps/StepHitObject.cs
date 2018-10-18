using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepHitObject : Step
{
    StayTrigger trigger;
    bool disable;

    public StepHitObject(PhaseController pc, StayTrigger tg, bool _disable = false): base(pc)
    {
        trigger = tg;
        disable = _disable;
    }

    public override bool isComplete()
    {
        return complete;
    }

    public override void Start()
    {
        trigger.gameObject.SetActive(true);
        player.activeInput = true;
    }

    public override void Update()
    {
        if (trigger.triggered)
        {
            complete = true;
            if(!disable) trigger.gameObject.SetActive(false);
        }
    } 

}
