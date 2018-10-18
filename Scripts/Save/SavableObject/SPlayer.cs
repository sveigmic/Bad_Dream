using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPlayer : SavableObject {

    Vector3 camPos;
    Vector3 pos;
    Quaternion rot;
    Vector3 scale;
 //   Vector2 velocity;
    float gravity;
    Phases phase;
    SuperAbility.Abilities ability = SuperAbility.Abilities.None;


    public override void Save()
    {
        camPos = Camera.main.transform.position;
        pos = transform.position;
        scale = transform.localScale;
        rot = transform.rotation;
        PhaseController pc = GetComponent<PhaseController>();
        phase = pc.actPhaseEnum;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
   //     velocity = rb.velocity;
        gravity = rb.gravityScale;
        if (pc.actualAbility != null) ability = pc.actualAbility.type;
        Debug.Log(ability + "  " + pc.actualAbility);
    }

    public override void Load()
    {
        Camera.main.transform.position = camPos;
        transform.position = pos;
        transform.rotation = rot;
        transform.localScale = scale;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        rb.gravityScale = gravity;
        PhaseController pc = GetComponent<PhaseController>();
        pc.SendRequestToChangePhase(phase);
        if (ability != SuperAbility.Abilities.None) pc.actualAbility = AbilityCreator.CreateAbility(ability, pc);
        else pc.ClearAbility();
    }
}
