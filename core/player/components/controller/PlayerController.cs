namespace Core.Player.Components.Controller;

using Constants.InputMap;
using Godot;

public partial class PlayerController(Player player) : RefCounted
{
    private Player _player = player;

    public (Vector3 direction, bool isJumping) GetInputDirection()
    {
        Vector2 input = Input.GetVector(LocalInputMap.LEFT, LocalInputMap.RIGHT, LocalInputMap.UP, LocalInputMap.DOWN);
        Vector3 direction = _player.Transform.Basis.Z * input.Y + _player.Transform.Basis.X * input.X;
        return (direction.Normalized(), Input.IsActionPressed(LocalInputMap.JUMP));
    }
}