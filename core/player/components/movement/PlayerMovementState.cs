namespace Core.Player.Components.MovementStates;

using Core.Player.Components.Movement;
using global::Components.StateMachine;
using Godot;

public abstract partial class PlayerMovementState(PlayerMovementMachine playerMovementMachine) : RefCounted, IState
{
    protected PlayerMovementMachine _playerMovementMachine = playerMovementMachine;

    public abstract void Execute(float delta);

    public abstract void PostExecution();

    public abstract void PreExecution();
}