using Core.Player.Components.Movement;
using Godot;

namespace Core.Player.Components.MovementStates.Vertical;

public partial class PlayerAscendingState(PlayerMovementMachine movementMachine, Player player) : PlayerMovementState(movementMachine)
{
    private readonly Player _player = player;
    private const float AirSpeed = 6f;

    public override void PreExecution()
    {
    }

    public override void Execute(float delta)
    {
        ApplyAirMovement(delta);
        _player.MoveAndSlide();

        if (_player.Velocity.Y >= 0)
        {
            _playerMovementMachine.ChangeState(_playerMovementMachine.FallingState);
        }
    }

    public override void PostExecution()
    {
    }

    private void ApplyAirMovement(float delta)
    {
        (Vector3 inputDir, _) = _player.Controller.GetInputDirection();

        if (inputDir.LengthSquared() > 0.01f)
        {
            Vector3 moveDir = new Vector3(inputDir.X, 0, inputDir.Z).Normalized();
            _player.Velocity = new Vector3(moveDir.X * AirSpeed, _player.Velocity.Y, moveDir.Z * AirSpeed);
        }
    }
}