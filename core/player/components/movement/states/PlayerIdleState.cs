namespace Core.Player.Components.MovementStates;

using Core.Player.Components.Movement;
using Godot;

public partial class PlayerIdleState(PlayerMovementMachine playerMovementMachine, Player player) : PlayerMovementState(playerMovementMachine)
{
    private readonly Player _player = player;

    public override void PreExecution()
    {
        _player.Velocity = new Vector3(0, _player.Velocity.Y, 0);
    }

    public override void Execute(float delta)
    {
        (Vector3 direction, bool isJumping) = _player.Controller.GetInputDirection();
        if (isJumping && _player.IsOnFloor())
        {
            _playerMovementMachine.ChangeState(_playerMovementMachine.JumpingState);
            return;
        }
        if (direction.Length() > 0.1f)
        {
            _playerMovementMachine.ChangeState(_playerMovementMachine.WalkingState);
            return;
        }
        if (!_player.IsOnFloor())
        {
            _playerMovementMachine.ChangeState(_playerMovementMachine.FallingState);
            return;
        }
        _player.MoveAndSlide();
    }

    public override void PostExecution()
    {
    }

}
