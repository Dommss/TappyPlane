using Godot;
using System;

public partial class Game : Node2D {
    [Export] private PackedScene _pipesScene;

    private GameManager _gameManager;
    
    private Node _pipesHolder;
    private Marker2D _spawnUp;
    private Marker2D _spawnLower;
    private Timer _timer;

    public override void _Ready() {
        _gameManager = GetNode<GameManager>("/root/GameManager");
        _pipesHolder = GetNode<Node>("PipesHolder");
        _spawnUp = GetNode<Marker2D>("SpawnU");
        _spawnLower = GetNode<Marker2D>("SpawnL");
        _timer = GetNode<Timer>("SpawnTimer");
        _timer.Timeout += OnSpawnTimerTimeout;
        _gameManager.GameOver += OnGameOver;
        _gameManager.SetScore(0);
        SpawnPipes();
    }

    private void SpawnPipes() {
        var yPos = GD.RandRange(_spawnUp.Position.Y, _spawnLower.Position.Y);
        var newPipes = _pipesScene.Instantiate() as Node2D;
        if (newPipes == null) return;

        newPipes.Position = new Vector2(_spawnLower.Position.X, (float)yPos);
        _pipesHolder.AddChild(newPipes);
    }

    private void StopPipes() {
        _timer.Stop();
        var pipeList = _pipesHolder.GetChildren();
        foreach (var pipe in pipeList) {
            pipe.SetProcess(false);
        }
    }

    private void OnGameOver() {
        StopPipes();
    }

    private void OnSpawnTimerTimeout() {
        SpawnPipes();
    }
}
