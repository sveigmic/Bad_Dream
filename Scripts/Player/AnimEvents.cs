using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEvents : MonoBehaviour {

    private BodyParts bp;
    private PhaseController pc;
    private Rigidbody2D rb;
    private Animator anim;
    private IKController iks;

    bool reset = false;

    private void Start()
    {
        bp = GetComponent<BodyParts>();
        rb = GetComponent<Rigidbody2D>();
        pc = GetComponent<PhaseController>();
        anim = GetComponent<Animator>();
    }

    public void LeaveRootMotion()
    {
        reset = true;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        pc.actualPhase.SendRequestToCreateState(PlayerStates.Move);
    }

    private void LateUpdate()
    {
        if(reset)
        {
            Vector3 tmp = bp.bones.position;
            foreach(Joint2D x in pc.joints)
            {
                Rigidbody2D trb = x.GetComponent<Rigidbody2D>();
                GameObject.Destroy(x);
                GameObject.Destroy(trb);
            }
            pc.joints.Clear();
            pc.transform.position = tmp;
            bp.bones.localPosition = Vector3.zero;
            anim.SetBool("grounded", true);
            anim.SetFloat("speed", 0f); 
            anim.Play("Movement");
            reset = false;
        }
    }
}
