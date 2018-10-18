using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Quest {

    protected PhaseController player;
    protected SupportController.UIPointers uip;
    protected bool complete = false;

    protected Step[] steps;
    protected string[] text;
    protected string[] smallText;

    protected int actStep = -1;

    public Quest(PhaseController pc, SupportController.UIPointers ui)
    {
        player = pc;
        uip = ui;
    }

    public abstract void Start();

    public abstract void Update();

    public abstract bool isComplete();

    public virtual void NextStep()
    {
        actStep++;
        if (actStep >= steps.Length)
        {
            complete = true;
            return;
        }
        steps[actStep].Start();
        uip.dialog.text = text[actStep];
        uip.smallDialog.text = smallText[actStep];
    }
}
