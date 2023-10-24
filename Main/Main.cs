using Godot;
using System;

public partial class Main : Control {
    private GameManager _gameManager;
    
    private Label _highScoreLabel;

    public override void _Ready() {
        _gameManager = GetNode<GameManager>("/root/GameManager");
        _highScoreLabel = GetNode<Label>("MC/HB/HighscoreLabel");
        _highScoreLabel.Text = _gameManager.GetHighScore().ToString();
    }

    public override void _Process(double delta) {
        if (Input.IsActionJustPressed("Fly")) {
            GetNode<GameManager>("/root/GameManager").LoadGameScene();
        }
    }
}
