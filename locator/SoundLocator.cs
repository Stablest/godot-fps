using Godot;

namespace Locator;

public partial class SoundLocator : RefCounted
{
    private static SoundLocator _instance = null!;
    public static SoundLocator Instance
    {
        get
        {
            _instance ??= new SoundLocator();
            return _instance;
        }
        private set
        {
            _instance = value;
        }
    }

    public AudioStream AbstractSound1 { get; private set; } = GD.Load<AudioStream>("res://assets/sound/abstract-1.wav");
    public AudioStream WoodBlockSound1 { get; private set; } = GD.Load<AudioStream>("res://assets/sound/wood-block-1.wav");

    private SoundLocator()
    {
        Instance = this;
    }
}