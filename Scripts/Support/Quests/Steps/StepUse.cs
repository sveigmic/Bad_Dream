using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepUse : Step
{
    UseTrigger trigger;

    public StepUse(PhaseController pc, UseTrigger tg): base(pc)
    {
        trigger = tg;
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
        if (trigger.complete)
        {
            complete = true;
        }
    }
}
