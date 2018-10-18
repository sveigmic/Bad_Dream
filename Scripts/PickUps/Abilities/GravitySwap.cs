using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwap : SuperAbility
{
    
    public GravitySwap(PhaseController pc, Abilities _type): base(pc, _type)
    {

    }

    public override void Activate()
    {
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        rb.gravityScale = -1 * rb.gravityScale;
        player.transform.Rotate(new Vector3(180, 0, 0));
        finished = true;
    }

    public override void Update()
    {
       
    }
}
