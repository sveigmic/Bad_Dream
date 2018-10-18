using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepDoubleJump : Step
{ 

    public StepDoubleJump(PhaseController pc) : base(pc)
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
        if (!player.grounder.IsGrounded() && (player.touchManager.AreaTap || Input.GetKeyDown(KeyCode.Space))) complete = true;
    }
}
