using Godot;
using System;

public partial class GameManager : Node {
    private Resource _gameScene = ResourceLoader.Load("res://Game/Game.tscn");
    private Resource _mainScene = ResourceLoader.Load("res://Main/Main.tscn");

    public void LoadGameScene() {
        GetTree().ChangeSceneToPacked((PackedScene)_gameScene);
    }

    public void LoadMainScene() {
        GetTree().ChangeSceneToPacked((PackedScene)_mainScene);
    }
}
