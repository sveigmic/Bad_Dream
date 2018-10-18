using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepObjectOnPlace : Step
{
    CheckTrigger trigger;

    public StepObjectOnPlace(PhaseController pc, CheckTrigger tg): base(pc)
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
            trigger.gameObject.SetActive(false);
        }
    }

}
