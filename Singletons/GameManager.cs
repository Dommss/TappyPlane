using Godot;
using System;
using System.Threading.Tasks.Sources;

public partial class GameManager : Node {
    [Signal] public delegate void GameOverEventHandler();

    [Signal] public delegate void PlaneCrashedEventHandler();

    [Signal] public delegate void ScoreUpdatedEventHandler();

    public string GroupPlane = "Plane";

    public int Score = 0;
    public int HighScore = 0;
    
    private Resource _gameScene = ResourceLoader.Load("res://Game/Game.tscn");
    private Resource _mainScene = ResourceLoader.Load("res://Main/Main.tscn");

    public int GetScore() {
        return Score;
    }

    public int GetHighScore() {
        return HighScore;
    }

    public void SetScore(int value) {
        Score = value;
        if (Score > HighScore) {
            HighScore = Score;
        }

        EmitSignal(SignalName.ScoreUpdated);
        GD.Print("sc: hs:" + Score + " ; " + HighScore);
    }

    public void IncrementScore() {
        SetScore(Score + 1);
    }
    
    public void LoadGameScene() {
        GetTree().ChangeSceneToPacked((PackedScene)_gameScene);
    }

    public void LoadMainScene() {
        GetTree().ChangeSceneToPacked((PackedScene)_mainScene);
    }
}
