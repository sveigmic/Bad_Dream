using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticBoots : SuperAbility
{

    public MagneticBoots(PhaseController pc, Abilities _type) : base(pc, _type)
    {

    }

    public override void Activate()
    {
        if (!player.grounder.IsGrounded())
        {
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Sign(rb.gravityScale) * -40);
        }
        finished = true;
    }

    public override void Update()
    {

    }
}
