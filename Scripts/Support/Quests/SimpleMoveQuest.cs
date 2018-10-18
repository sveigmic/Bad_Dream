using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMoveQuest : Quest
{
    public SimpleMoveQuest(PhaseController pc, SupportController.UIPointers ui) : base(pc, ui)
    {
        player = pc;
        pc.activeInput = false;
        steps = new Step[18];
        text = new string[18];
        smallText = new string[18];
        steps[0] = new StepTap(player);
        text[0] = "This joystick controls movement.";
        smallText[0] = "Swipe right to continue...";
        steps[1] = new StepHitObject(player,uip.resources["movement"][0].GetComponent<StayTrigger>());
        text[1] = "Try to get to the highlighted location.";
        smallText[1] = "";
        steps[2] = new StepHitObject(player, uip.resources["movement"][1].GetComponent<StayTrigger>());
        text[2] = "Great. Now the second direction.";
        smallText[2] = "";
        steps[3] = new StepJump(player);
        text[3] = "Good, now jumping..." + System.Environment.NewLine + "You can jump by the touch on the right half of the screen.";
        smallText[3] = "";
        steps[4] = new StepDoubleJump(player);
        text[4] = "Nice! Let's do a doublejump." + System.Environment.NewLine + "Do a doublejump by the touch on the right half of the screen, when you're in the air.";
        smallText[4] = "";
        steps[5] = new StepTap(player);
        text[5] = "Wohoo!" + System.Environment.NewLine + "What about climbing?";
        smallText[5] = "Swipe right to continue...";
        steps[6] = new StepHitObject(player, uip.resources["ledge"][1].GetComponent<StayTrigger>());
        text[6] = "Jump beside place, where you want to climb and hold screen anyway in the right half." + System.Environment.NewLine
            + "Then swipe up / swipe down or use joystick to climb ledge / fall of the ledge.";
        smallText[6] = "";
        steps[7] = new StepUse(player, uip.resources["lever"][0].GetComponent<UseTrigger>());
        text[7] = "Good job!" + System.Environment.NewLine
            + "Now use the lever. Just go to the lever and swipe up on the right half of the screen.";
        smallText[7] = "";
        steps[8] = new StepObjectOnPlace(player, uip.resources["box"][0].GetComponent<CheckTrigger>());
        text[8] = "Be careful! The box is falling." + System.Environment.NewLine
            + "Push the box to the highlighted location.";
        smallText[8] = "";
        steps[9] = new StepHitObject(player, uip.resources["movement"][2].GetComponent<StayTrigger>());
        text[9] = "Great, now get to the higlighted location" + System.Environment.NewLine + "Remember about climbing..";
        smallText[9] = "";
        steps[10] = new StepTap(player);
        text[10] = "Here is your bonus button." + System.Environment.NewLine + "But you need bonus to charge it...";
        smallText[10] = "Swipe right to continue...";
        steps[11] = new StepHitObject(player, uip.resources["bonus"][0].GetComponent<StayTrigger>(), true);
        text[11] = "Oh! Here is a bonus." + System.Environment.NewLine + "Get it!";
        smallText[11] = "";
        steps[12] = new StepHitObject(player, uip.resources["movement"][3].GetComponent<StayTrigger>());
        text[12] = "Now use the bonus. Just click on the bonus button.";
        smallText[12] = "";
        steps[13] = new StepHitObject(player, uip.resources["movement"][4].GetComponent<StayTrigger>());
        text[13] = "Good. Get to the higlighted location";
        smallText[13] = "";
        steps[14] = new StepHitObject(player, uip.resources["movement"][5].GetComponent<StayTrigger>());
        text[14] = "Nice. Continue to the higlighted location";
        smallText[14] = "";
        steps[15] = new StepTap(player);
        text[15] = "Oh no, Dead fog! You have to escape from it!" + System.Environment.NewLine + "You can jump by tapping anywhere on the screen.";
        smallText[15] = "Swipe right to continue...";
        steps[16] = new StepHitObject(player, uip.resources["movement"][6].GetComponent<StayTrigger>());
        text[16] = "Run!";
        smallText[16] = "";
        steps[17] = new StepTap(player);
        text[17] = "Congratulation, now you know how to control the guy.";
        smallText[17] = "Swipe right to continue...";

    }

    public override bool isComplete()
    {
        return complete;
    }

    public override void Start()
    {
        NextStep();
        uip.normalUI.gameObject.SetActive(true);
        player.joystick.gameObject.SetActive(true);
    }

    public override void Update()
    {
        Time.timeScale = 1;
        if(actStep == 5)
        {
            uip.resources["ledge"][0].SetActive(true);
        } else if(actStep == 10)
        {
            uip.abilityBtn.gameObject.SetActive(true);
        }
        else if (actStep == 15)
        {
            Time.timeScale = 0;
        }

        else if (actStep == 17)
        {
            player.activeInput = false;
            player.joystick.gameObject.SetActive(false);
        }

        if (!complete)
        {
            steps[actStep].Update();
            if (steps[actStep].isComplete()) NextStep();
        }
    }
}
