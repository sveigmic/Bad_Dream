using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirRunState : ObjectState {

    private bool doubleJumped = false;
    private float fallMultiplier = 2.5f;

    private Animator anim;
    private Rigidbody2D rb;
    private LayerMask layer;

    public AirRunState(PhaseController _player) : base(_player)
    {
        layer = ~((1 << 9) | (1 << 12) | (1 << 13));
        anim = player.GetComponent<Animator>();
        rb = player.GetComponent<Rigidbody2D>();
        Enter();
    }

    public override void Enter()
    {
        anim.SetBool("grounded", false);
    }

    public override void EarlyUpdate()
    {
        if (!player.grounder.IsGrounded())
        {
            anim.SetFloat("vSpeed", -rb.velocity.y);
            float sign = Mathf.Sign(rb.gravityScale);
            rb.gravityScale = sign * ((sign*rb.velocity.y < 0) ? fallMultiplier : 1);

        }
        else
        {
            player.actualPhase.SendRequestToCreateState(PlayerStates.RunState);
        }
    }

    public override void HandleInput()
    {
        if ((player.touchManager.Tap || player.touchManager.AreaTap || Input.GetKeyDown(KeyCode.Space)) && !doubleJumped)
        {
            rb.velocity = new Vector2(rb.velocity.x, player.attributes.jumpForce * player.attributes.doubleJumpMultiplier * Mathf.Sign(rb.gravityScale));
            doubleJumped = true;
        }
    }

    public override void Update()
    {
        RaycastHit2D hit = Physics2D.BoxCast(player.airColl.bounds.center, player.airColl.size, 0, Vector2.right, 0.1f, layer.value);
        if (!hit)
        {
            float tmp = rb.velocity.x + player.attributes.runAcceleration * Time.deltaTime;
            if (tmp > player.attributes.maxRunVelocity) tmp = player.attributes.maxRunVelocity;
            rb.velocity = new Vector2(tmp, rb.velocity.y);

            float norm = tmp / player.attributes.maxRunVelocity;
            anim.SetFloat("speed", norm);
        }
    }

    public override void FixedUpdate()
    {
    }
}
