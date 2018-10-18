using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SuperAbility {

    public enum Abilities
    {
        None,
        GravitySwap,
        MagneticBoots,
    }

    protected bool finished;
    protected PhaseController player;
    public Sprite image;
    public Abilities type;

    public SuperAbility(PhaseController pc, Abilities _type)
    {
        player = pc;
        finished = false;
        type = _type;
    }

    public abstract void Activate();

    public abstract void Update();

    public bool IsFinished()
    {
        return finished;
    }
}
