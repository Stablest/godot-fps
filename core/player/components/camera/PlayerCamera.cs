namespace Core.Player.Components.Camera;
using Godot;

public partial class PlayerCamera : Camera3D
{
    private float _rotationY = 0f;
    private const float LookAroundSpeed = 0.001f;

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event is InputEventMouseMotion mouseMotion)
        {
            _rotationY += -mouseMotion.Relative.Y * LookAroundSpeed;
            Transform3D transform = Transform;
            transform.Basis = Basis.Identity;
            Transform = transform;
            Rotate(Vector3.Right, Mathf.Clamp(_rotationY, -Mathf.Pi / 2, Mathf.Pi / 2));
        }
    }
}
