namespace Components.Gravity;
using Godot;

public partial class Gravity(CharacterBody3D characterBody) : RefCounted
{
    private const float GravityForce = -4.9f;
    private const float TerminalVelocity = -50f;
    private CharacterBody3D _characterBody = characterBody;

    public void ExecutePooling()
    {
        if (!_characterBody.IsOnFloor())
        {
            _characterBody.Velocity += new Vector3(0, GravityForce, 0);
            if (_characterBody.Velocity.Y < TerminalVelocity)
            {
                _characterBody.Velocity = new Vector3(_characterBody.Velocity.X, TerminalVelocity, _characterBody.Velocity.Z);
            }
        }
    }
}