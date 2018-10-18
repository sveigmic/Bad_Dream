using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalPhase : Phase
{
    private TouchManager touchManager;


    public NormalPhase(PhaseController _player) : base(_player)
    {
        
        touchManager = player.touchManager;
        Enter();
        CreateState(PlayerStates.Move);
    }

    public override void Enter()
    {
        Debug.Log("Change");
        player.gameMaster.ActivateUIByPhase(Phases.Normal);
        player.gameMaster.ActivateCameraByPhase(Phases.Normal);
        player.joystick.Reset();
    }

    private void HandleInput()
    {
        if (!player.activeInput) return;
        if((touchManager.SwipeUp || Input.GetKeyDown(KeyCode.K)) && !player.inAction && player.viableAction.Count != 0)
        {
            CreateState(PlayerStates.Action);
        }
    }

    protected override void EarlyUpdate()
    {
        if((player.transform.position.y < player.bottomDieAnchor) || (player.transform.position.y > player.topDieAnchor))
        {
            player.gameMaster.GameOverShow(true);
        }
        HandleInput();
    }
}
