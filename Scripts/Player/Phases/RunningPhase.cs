using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningPhase : Phase
{

    private Rigidbody2D rb;
    Camera camera;

    public RunningPhase(PhaseController _player) : base(_player)
    {
        camera = Camera.main.GetComponent<Camera>();
        rb = player.GetComponent<Rigidbody2D>();
        Enter();
        CreateState(PlayerStates.RunState);
    }

    public override void Enter()
    {
        player.gameMaster.ActivateUIByPhase(Phases.Running);
        player.gameMaster.ActivateCameraByPhase(Phases.Running);
        player.fogOfDead.SpawnFog();
    }

    protected override void EarlyUpdate()
    {
        Vector3 cornPos = camera.ViewportToWorldPoint(new Vector3(0, 1, camera.nearClipPlane));
        if (player.transform.position.x < cornPos.x || ((player.transform.position.y < player.bottomDieAnchor) || (player.transform.position.y > player.topDieAnchor)))
        {
            player.gameMaster.GameOverShow(true);
        }
    }

    public override void Leave()
    {
        player.fogOfDead.HideFog();
    }
}
