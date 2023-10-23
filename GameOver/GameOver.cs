using Godot;
using System;

public partial class GameOver : Control {
    private Label _gameOverLabel;
    private Label _pressSpaceLabel;
    private Timer _timer;

    private bool _canPressSpace = false;

    public override void _Ready() {
        _gameOverLabel = GetNode<Label>("GameOverLabel");
        _pressSpaceLabel = GetNode<Label>("PressSpaceLabel");
        _timer = GetNode<Timer>("Timer");
        _timer.Timeout += OnTimerTimeout;
        OnGameOver();
    }

    public override void _Process(double delta) {
        if (_canPressSpace) {
            if (Input.IsActionJustPressed("Fly")) {
                GetNode<GameManager>("/root/GameManager").LoadMainScene();
            }
        }
    }

    private void OnGameOver() {
        Show();
        _timer.Start();
    }

    private void RunSequence() {
        _gameOverLabel.Hide();
        _pressSpaceLabel.Show();
        _canPressSpace = true;
    }

    private void OnTimerTimeout() {
        RunSequence();
    }
}
