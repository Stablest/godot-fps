namespace Core.Player.Components.MovementStates;

using Core.Player.Components.Movement;
using Godot;

public partial class PlayerWalkingState(PlayerMovementMachine playerMovementMachine, Player player) : PlayerMovementState(playerMovementMachine)
{
    private readonly Player _player = player;

    public override void PreExecution()
    {
    }

    public override void Execute(float delta)
    {
        (Vector3 direction, bool isJumping) = _player.Controller.GetInputDirection();
        if (isJumping)
        {
            _playerMovementMachine.ChangeState(_playerMovementMachine.JumpingState);
            return;
        }
        if (direction.LengthSquared() < 0.1f)
        {
            _playerMovementMachine.ChangeState(_playerMovementMachine.IdleState);
            return;
        }
        ApplyWalkingMovement(direction);
        _player.MoveAndSlide();
    }

    public override void PostExecution()
    {
    }

    private void ApplyWalkingMovement(Vector3 direction)
    {
        float walkSpeed = 10f;
        var moveDirection = new Vector3(direction.X, 0, direction.Z);
        _player.Velocity = new Vector3(moveDirection.X, _player.Velocity.Y, moveDirection.Z) * walkSpeed;
    }
}
