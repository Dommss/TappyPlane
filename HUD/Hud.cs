using Godot;
using System;

public partial class Hud : Control {
    private GameManager _gameManager;
    
    private Label _scoreLabel;

    public override void _Ready() {
        _gameManager = GetNode<GameManager>("/root/GameManager");
        _scoreLabel = GetNode<Label>("MC/ScoreLabel");
        _gameManager.ScoreUpdated += OnScoreUpdated;
    }

    public override void _ExitTree() {
        _gameManager.ScoreUpdated -= OnScoreUpdated;
    }

    private void OnScoreUpdated() {
        _scoreLabel.Text = _gameManager.GetScore().ToString();
    }
}
