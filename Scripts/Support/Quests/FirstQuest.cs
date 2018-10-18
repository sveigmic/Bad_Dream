using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstQuest : Quest
{
    public FirstQuest(PhaseController pc, SupportController.UIPointers ui) : base(pc, ui)
    {
        player = pc;
        pc.activeInput = false;
        steps = new Step[1];
        text = new string[1];
        smallText = new string[1];
        steps[0] = new StepTap(player);
        text[0] = "Welcome to the movement tutorial!" + System.Environment.NewLine
                 + "Now, let's go through the basic controls.";
        smallText[0] = "Swipe right to continue...";
    }

    public override bool isComplete()
    {
        return complete;
    }

    public override void Start()
    {
        NextStep();
    }

    public override void Update()
    {
        if (!complete)
        {
            steps[actStep].Update();
            if (steps[actStep].isComplete()) NextStep();
        }
    }
}
