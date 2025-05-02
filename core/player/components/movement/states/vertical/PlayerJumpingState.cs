using Core.Player.Components.Movement;

namespace Core.Player.Components.MovementStates;

public partial class PlayerJumpingState(PlayerMovementMachine movementMachine, Player player) : PlayerMovementState(movementMachine)
{
    private readonly Player _player = player;
    private const float JumpVelocity = 5f;

    public override void PreExecution()
    {
        var velocity = _player.Velocity;
        velocity.Y = JumpVelocity;
        _player.Velocity = velocity;
    }

    public override void Execute(float delta)
    {
        _player.MoveAndSlide();
        if (_player.Velocity.Y == 0)
        {
            _playerMovementMachine.ChangeState(_playerMovementMachine.IdleState);
            return;
        }
        if (_player.Velocity.Y < 0)
        {
            _playerMovementMachine.ChangeState(_playerMovementMachine.AscendingState);
            return;
        }
        if (_player.Velocity.Y > 0)
        {
            _playerMovementMachine.ChangeState(_playerMovementMachine.FallingState);
            return;
        }
    }

    public override void PostExecution()
    {
    }
}