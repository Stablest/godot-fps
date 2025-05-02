namespace Core.Game;

using Godot;
using Core.Gameplay;
using Screen;


public partial class Game : Node2D
{
    [ExportCategory("Packed Scenes")]
    [Export]
    private PackedScene gameplayScene = null!;
    [Export]
    private PackedScene mainMenuScene = null!;

    private MainMenuScreen? mainMenu;
    private Gameplay? gameplay;

    public override void _Ready()
    {
        CreateMainMenu();
    }

    private void CreateMainMenu()
    {
        mainMenu = mainMenuScene.Instantiate<MainMenuScreen>();
        mainMenu.StartGameClicked += OnMainMenuStartGame;
        mainMenu.GameOptionsClicked += OnMainMenuGameOptions;
        mainMenu.ExitGameClicked += OnMainMenuExitGame;
        AddChild(mainMenu);
    }

    private void CreateGameplay()
    {
        Gameplay gameplay = gameplayScene.Instantiate<Gameplay>();
        if (!IsInstanceValid(gameplay))
        {
            return;
        }
        AddChild(gameplay);
    }

    private void ExitGameplay()
    {
        gameplay?.QueueFree();
    }

    private void OnGameplayPause()
    {
        gameplay?.SetPhysicsProcess(false);
    }

    private void OnGameplayResume()
    {
        gameplay?.SetPhysicsProcess(true);
    }

    private void OnGameplayExit()
    {
        mainMenu?.Show();
    }

    private void OnMainMenuStartGame()
    {
        CreateGameplay();
        mainMenu?.Hide();
    }

    private void OnMainMenuGameOptions()
    {
    }

    private void OnMainMenuExitGame()
    {
        GetTree().Quit();
    }
}
