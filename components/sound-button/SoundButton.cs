namespace Components.SoundButton;
using Godot;

public partial class SoundButton : Button
{
    [Export]
    public AudioStream mouseEnteredAudioStream = null!;
    [Export]
    public AudioStream buttonUpAudioStream = null!;

    private AudioStreamPlayer mouseEnteredAudioStreamPlayer = null!;
    private AudioStreamPlayer buttonUpAudioStreamPlayer = null!;

    public override void _Ready()
    {
        CreateAndConfigureMouseEnteredStreamPlayer();
        CreateAndConfigureButtonUpStreamPlayer();
        MouseEntered += OnMouseEntered;
        ButtonUp += OnButtonUp;
    }

    private void CreateAndConfigureMouseEnteredStreamPlayer()
    {
        mouseEnteredAudioStreamPlayer = new()
        {
            Stream = mouseEnteredAudioStream
        };
        AddChild(mouseEnteredAudioStreamPlayer);
    }

    private void CreateAndConfigureButtonUpStreamPlayer()
    {
        buttonUpAudioStreamPlayer = new()
        {
            Stream = buttonUpAudioStream
        };
        AddChild(buttonUpAudioStreamPlayer);
    }

    private void OnMouseEntered()
    {
        mouseEnteredAudioStreamPlayer.Play();
    }

    private void OnButtonUp()
    {
        buttonUpAudioStreamPlayer.Play();
    }

}
