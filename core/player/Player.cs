namespace Core.Player;

using Core.Player.Components.Controller;
using Core.Player.Components.Movement;
using global::Components.Gravity;
using Godot;


public partial class Player : CharacterBody3D
{
    private float _rotationX = 0f;
    private const float LookAroundSpeed = 0.001f;
    private PlayerMovementMachine _playerMovementMachine;
    private Gravity _gravity;

    public PlayerController Controller { get; private set; }

    public Player()
    {
        Controller = new PlayerController(this);
        _gravity = new Gravity(this);
        _playerMovementMachine = new PlayerMovementMachine(this);
    }

    public override void _PhysicsProcess(double delta)
    {
        _playerMovementMachine.Execute((float)delta);
    }


    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event is InputEventMouseMotion mouseMotion)
        {
            _rotationX += -mouseMotion.Relative.X * LookAroundSpeed;
            Transform3D transform = Transform;
            transform.Basis = Basis.Identity;
            Transform = transform;
            Rotate(Vector3.Up, _rotationX);
        }
    }
}

