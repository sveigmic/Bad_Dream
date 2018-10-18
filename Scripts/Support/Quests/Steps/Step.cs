using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Step {

    protected PhaseController player;
    protected bool complete = false;

    public Step(PhaseController pc)
    {
        player = pc;
    }

    public abstract void Start();

    public abstract void Update();

    public abstract bool isComplete();
}
