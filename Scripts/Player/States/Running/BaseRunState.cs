using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRunState : ObjectState
{
    private Attributes attrs;
    private Rigidbody2D rb;
    private Animator anim;
    private TouchManager tm;

    public BaseRunState(PhaseController _player): base(_player)
    {
        Enter();
    }

    public override void Enter()
    {

        rb = player.GetComponent<Rigidbody2D>();
        attrs = player.attributes;
        anim = player.GetComponent<Animator>();
        tm = player.touchManager;

        anim.SetBool("grounded", true);
    }

    public override void EarlyUpdate()
    {
        if (!player.grounder.IsGrounded())
        {
            player.actualPhase.SendRequestToCreateState(PlayerStates.AirRunState);
        }
    }

    public override void HandleInput()
    {
       if(tm.AreaTap || tm.Tap || Input.GetKeyDown(KeyCode.Space))
        {
            if (player.grounder.IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, player.attributes.jumpForce * Mathf.Sign(rb.gravityScale));
                player.actualPhase.SendRequestToCreateState(PlayerStates.AirRunState);
            }
        }
    }

    public override void Update()
    {

        if (player.grounder.IsGrounded())

        {
            float tmp = rb.velocity.x + attrs.runAcceleration * Time.deltaTime;
            if (tmp > attrs.maxRunVelocity) tmp = attrs.maxRunVelocity;
            rb.velocity = new Vector2(tmp, rb.velocity.y);

            float norm = tmp / attrs.maxRunVelocity;
            anim.SetFloat("speed", norm);
        }
    }

    public override void FixedUpdate()
    {
    }
}
