using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepJump : Step
{

    Rigidbody2D rb;

    public StepJump(PhaseController pc): base(pc)
    {

    }

    public override bool isComplete()
    {
        return complete;
    }

    public override void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
    }

    public override void Update()
    {
        if (rb.velocity.y > 3)
        {
            complete = true;
        }
    }
}
