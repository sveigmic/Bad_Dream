using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirState : ObjectState
{
    private bool doubleJumped = false;
    private float fallMultiplier = 2.5f;

    private Animator anim;
    private Rigidbody2D rb;

    private LayerMask layer;


    public AirState(PhaseController _player) : base(_player)
    {
        anim = player.GetComponent<Animator>();
        rb = player.GetComponent<Rigidbody2D>();
        Enter();
    }

    public override void Enter()
    {
        layer = ~((1 << 9) | (1 << 12) | (1 << 13));
        anim.SetBool("grounded", false);
    }

    public override void EarlyUpdate()
    {
        if (!player.grounder.IsGrounded())
        {
            anim.SetFloat("vSpeed", -rb.velocity.y);
            float sign = Mathf.Sign(rb.gravityScale);
            rb.gravityScale = sign * ((sign * rb.velocity.y < 0) ? fallMultiplier : 1);
            
        }
        else
        {
            player.actualPhase.SendRequestToCreateState(PlayerStates.Move);
        }
    }

    public override void HandleInput()
    {
        if(player.joystick.IsThereInput())
        {
            float x = player.joystick.Input.x;
            RaycastHit2D hit = Physics2D.BoxCast(player.airColl.bounds.center, player.airColl.size, 0, Vector2.right * Mathf.Sign(x), 0.1f, layer.value);
            if (hit)
            {
                Debug.Log("Hit + " + hit.transform.name);
            }
            else
            {
                if(Mathf.Abs(rb.velocity.x) < player.attributes.moveSpeed)
                {
                    rb.AddForce(new Vector2(player.attributes.moveSpeed * Time.deltaTime * 100 * x, 0));
                } else
                {
                    if ((x > 0) && (rb.velocity.x < 0))
                    {
                        rb.AddForce(new Vector2(player.attributes.moveSpeed *Time.deltaTime * 100 * x, 0));
                    }
                    else if ((x < 0) && (rb.velocity.x > 0))
                    {
                        rb.AddForce(new Vector2(player.attributes.moveSpeed *Time.deltaTime * 100 * x, 0));
                    }
                }
            }
            player.transform.localScale = new Vector3(Mathf.Sign(x) * 1, 1, 1);
        }   
        if ((player.touchManager.AreaTap || Input.GetKeyDown(KeyCode.Space)) && !doubleJumped)
        {
            rb.velocity = new Vector2(rb.velocity.x, player.attributes.jumpForce * player.attributes.doubleJumpMultiplier * Mathf.Sign(rb.gravityScale));
            doubleJumped = true;
        }
        if(player.touchManager.AreaHolding || Input.GetKey(KeyCode.F))
        {
            HangUpdate();
        }
    }

    public override void Update()
    {
        DrawBoxCast(player.airColl.bounds.center, player.airColl.size, Color.red);
    }

    private void HangUpdate()
    {
        if (player.viableHangs.Count != 0)
        {
            float min = Mathf.Infinity;
            HangObject best = null;
            foreach (HangObject x in player.viableHangs)
            {
                if (x.Validate())
                {
                    float tmp = (player.transform.position - x.hangPoint.transform.position).magnitude;
                    if (tmp < min)
                    {
                        min = tmp;
                        best = x;
                    }
                }
            }
            if (best != null)
            {
                player.actualHang = best;
                player.actualPhase.SendRequestToCreateState(PlayerStates.Hang);
            }
        }
    }

    public override void FixedUpdate()
    {
    }

    private void DrawBoxCast(Vector2 origin, Vector2 size, Color color)
    {
        Vector2 downLeft = new Vector2(origin.x - size.x / 2, origin.y - size.y / 2);
        Vector2 downRight = new Vector2(origin.x + size.x / 2, origin.y - size.y / 2);
        Vector2 upLeft = new Vector2(origin.x - size.x / 2, origin.y + size.y / 2);
        Vector2 upRight = new Vector2(origin.x + size.x / 2, origin.y + size.y / 2);
        Debug.DrawLine(downLeft, downRight, color);
        Debug.DrawLine(downRight, upRight, color);
        Debug.DrawLine(upRight, upLeft, color);
        Debug.DrawLine(upLeft, downLeft, color);
    }
}
