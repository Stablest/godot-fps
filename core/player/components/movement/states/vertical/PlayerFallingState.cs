namespace Core.Player.Components.MovementStates;

using Core.Player.Components.Movement;
using Godot;

public partial class PlayerFallingState(PlayerMovementMachine playerMovementMachine, Player player) : PlayerMovementState(playerMovementMachine)
{
    private readonly Player _player = player;
    private const float AirSpeed = 6f;

    public override void PreExecution()
    {
    }

    public override void Execute(float delta)
    {
        (Vector3 inputDirection, bool isJumping) = _player.Controller.GetInputDirection();
        if (!_player.IsOnFloor())
        {
            ApplyAirMovement(inputDirection, delta);
            _player.Velocity = new Vector3(_player.Velocity.X, Mathf.Max(_player.Velocity.Y - 12f * delta, -20f), _player.Velocity.Z);
            _player.MoveAndSlide();
            return;
        }

        if (isJumping)
        {
            _playerMovementMachine.ChangeState(_playerMovementMachine.JumpingState);
            return;
        }
        var nextState = inputDirection.LengthSquared() > 0.1f
            ? _playerMovementMachine.WalkingState
            : _playerMovementMachine.IdleState;

        _playerMovementMachine.ChangeState(nextState);
    }

    public override void PostExecution()
    {
    }

    private void ApplyAirMovement(Vector3 inputDirection, float delta)
    {
        if (inputDirection.LengthSquared() > 0.01f)
        {
            Vector3 moveDir = new Vector3(inputDirection.X, 0, inputDirection.Z).Normalized();
            _player.Velocity = new Vector3(moveDir.X * AirSpeed, _player.Velocity.Y, moveDir.Z * AirSpeed);
        }
    }
}
