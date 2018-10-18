using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Phases
{
    Normal,
    Running
}


abstract public class Phase
{
    protected ObjectState actualState;
    protected PhaseController player;

    protected Queue<PlayerStates> stateRequests;

    public Phase(PhaseController _player)
    {
        player = _player;
        stateRequests = new Queue<PlayerStates>();
    }

    public virtual void Enter()
    {

    }

    protected virtual void EarlyUpdate()
    {
        
    }

    protected virtual void LateUpdate()
    {

    }

    public virtual void FixedUpdate()
    {

    }

    public virtual void Leave()
    {

    }


    public virtual void Update()
    {
        EarlyUpdate();
        actualState.EarlyUpdate();
        if (player.activeInput) actualState.HandleInput();
        actualState.Update();
        if (stateRequests.Count != 0)
        {
            CreateState(stateRequests.Dequeue());
            stateRequests.Clear();
        }
    }

    public void CreateState(PlayerStates _state)
    {
        player.inAction = false;
        switch (_state)
        {
            case PlayerStates.Move:
                actualState = new MoveState(player);
                break;
            case PlayerStates.Air:
                actualState = new AirState(player);
                break;
            case PlayerStates.Hang:
                actualState = new HangState(player);
                break;
            case PlayerStates.Action:
                player.inAction = true;
                actualState = new ActionState(player);
                break;
            case PlayerStates.RunState:
                player.inAction = true;
                actualState = new BaseRunState(player);
                break;
            case PlayerStates.AirRunState:
                player.inAction = true;
                actualState = new AirRunState(player);
                break;
            default:
                actualState = new MoveState(player);
                break;
        }
    }

    public void SendRequestToCreateState(PlayerStates state)
    {
        stateRequests.Enqueue(state);
    }
}
