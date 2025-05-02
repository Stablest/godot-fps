namespace Core.Player.Components.Movement;

using System;
using Core.Player.Components.MovementStates;
using Core.Player.Components.MovementStates.Vertical;
using Godot;

public partial class PlayerMovementMachine : RefCounted
{
    public PlayerMovementState IdleState { get; }
    public PlayerMovementState WalkingState { get; }
    public PlayerMovementState JumpingState { get; }
    public PlayerMovementState AscendingState { get; }
    public PlayerMovementState FallingState { get; }

    private PlayerMovementState _currentState;

    public PlayerMovementMachine(Player player)
    {
        IdleState = new PlayerIdleState(this, player);
        WalkingState = new PlayerWalkingState(this, player);
        JumpingState = new PlayerJumpingState(this, player);
        AscendingState = new PlayerAscendingState(this, player);
        FallingState = new PlayerFallingState(this, player);
        _currentState = IdleState;
        _currentState.PreExecution();
    }

    public void ChangeState(PlayerMovementState newState)
    {
        if (_currentState == newState)
        {
            throw new ArgumentNullException(nameof(newState));
        }
        _currentState.PostExecution();
        _currentState = newState;
        _currentState.PreExecution();
    }

    public void Execute(float delta)
    {
        _currentState.Execute(delta);
    }

}
