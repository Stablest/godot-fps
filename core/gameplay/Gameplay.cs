namespace Core.Gameplay;
using Godot;

public partial class Gameplay : Node3D
{
    public override void _Ready()
    {
        Input.MouseMode = Input.MouseModeEnum.Captured;
    }
}
