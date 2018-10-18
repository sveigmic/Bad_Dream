using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepTap : Step
{

    public StepTap(PhaseController pc): base(pc)
    {
    }

    public override bool isComplete()
    {
        return complete;
    }

    public override void Start()
    {
    }

    public override void Update()
    {
        if(player.touchManager.AreaSwipeRight || player.touchManager.SwipeRight || Input.GetKeyDown(KeyCode.S))
        {
            complete = true;
        }
    }
}
