using Godot;
using System;

public partial class Pipes : Node2D {
    private float _scrollSpeed = 150f;

    private GameManager _gameManager;

    private Area2D _laser;
    private Area2D _upperPipe;
    private Area2D _lowerPipe;
    private VisibleOnScreenNotifier2D _notifier;

    private AudioStreamPlayer _scoreSound;

    public override void _Ready() {
        _gameManager = GetNode<GameManager>("/root/GameManager");
        _notifier = GetNode<VisibleOnScreenNotifier2D>("VisibleOnScreenNotifier2D");
        _laser = GetNode<Area2D>("Laser");
        _upperPipe = GetNode<Area2D>("UpperPipe");
        _lowerPipe = GetNode<Area2D>("LowerPipe");
        _scoreSound = GetNode<AudioStreamPlayer>("ScoreSound");
        _notifier.ScreenExited += OnScreenExited;
        _upperPipe.BodyEntered += OnPipeEntered;
        _lowerPipe.BodyEntered += OnPipeEntered;
        _laser.BodyEntered += OnLaserEntered;
    }

    public override void _Process(double delta) {
        var position = Position;
        position.X -= _scrollSpeed * (float)delta;
        Position = position;
    }

    private void PlayerScored() {
        _scoreSound.Play();
        _gameManager.IncrementScore();
    }

    private void OnLaserEntered(Node2D body) {
        if (body.IsInGroup(_gameManager.GroupPlane)) {
            PlayerScored();
        }
    }

    private void OnPipeEntered(Node2D body) {
        if (body.IsInGroup(_gameManager.GroupPlane)) {
            _gameManager.EmitSignal(GameManager.SignalName.PlaneCrashed);
        }

    }

    private void OnScreenExited() {
        QueueFree();
    }
}
