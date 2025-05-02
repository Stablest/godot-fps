namespace Screen;

using Godot;

public partial class MainMenuScreen : CanvasLayer
{
    [Export]
    public Button startGameButton = null!;
    [Export]
    public Button gameOptionsButton = null!;
    [Export]
    public Button exitGameButton = null!;

    [Signal]
    public delegate void StartGameClickedEventHandler();
    [Signal]
    public delegate void GameOptionsClickedEventHandler();
    [Signal]
    public delegate void ExitGameClickedEventHandler();

    public override void _Ready()
    {
        startGameButton.ButtonUp += OnStartGameButtonPressed;
        gameOptionsButton.ButtonUp += OnGameOptionsButtonPressed;
        exitGameButton.ButtonUp += OnExitGameButtonPressed;
    }

    private void OnStartGameButtonPressed()
    {
        EmitSignal(SignalName.StartGameClicked);
    }

    private void OnGameOptionsButtonPressed()
    {
        EmitSignal(SignalName.GameOptionsClicked);
    }

    private void OnExitGameButtonPressed()
    {
        EmitSignal(SignalName.ExitGameClicked);
    }
}
