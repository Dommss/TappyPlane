using Godot;
using System;

public partial class ScrollingBg : ParallaxBackground {
    private GameManager _gameManager;
    
    private float _speed = 120f;

    public override void _Ready() {
        _gameManager = GetNode<GameManager>("/root/GameManager");
        _gameManager.GameOver += OnGameOver;
    }

    public override void _Process(double delta) {
        var scrollOffset = ScrollOffset;
        scrollOffset.X += _speed * (float)delta;
        ScrollOffset = scrollOffset;
    }

    private void OnGameOver() {
        SetProcess(false);
    }
}
