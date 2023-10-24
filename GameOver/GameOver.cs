using Godot;
using System;

public partial class GameOver : Control {
    private GameManager _gameManager;
    
    private Label _gameOverLabel;
    private Label _pressSpaceLabel;
    private Timer _timer;

    private bool _canPressSpace = false;

    public override void _Ready() {
        _gameOverLabel = GetNode<Label>("GameOverLabel");
        _pressSpaceLabel = GetNode<Label>("PressSpaceLabel");
        _gameManager = GetNode<GameManager>("/root/GameManager");
        _timer = GetNode<Timer>("Timer");
        _timer.Timeout += OnTimerTimeout;
        _gameManager.GameOver += OnGameOver;
    }

    public override void _Process(double delta) {
        if (_canPressSpace) {
            if (Input.IsActionJustPressed("Fly")) {
                _gameManager.LoadMainScene();
            }
        }
    }

    public override void _ExitTree() {
        _timer.Timeout -= OnTimerTimeout;
        _gameManager.GameOver -= OnGameOver;
    }

    private void RunSequence() {
        _gameOverLabel.Hide();
        _pressSpaceLabel.Show();
        _canPressSpace = true;
    }

    private void OnGameOver() {
        Show();
        _timer.Start();
    }

    private void OnTimerTimeout() {
        RunSequence();
    }
}
