using Godot;
using System;

public partial class Pipes : Node2D {
    private float _scrollSpeed = 150f;

    private VisibleOnScreenNotifier2D _notifier;

    public override void _Ready() {
        _notifier = GetNode<VisibleOnScreenNotifier2D>("VisibleOnScreenNotifier2D");
        _notifier.ScreenExited += OnScreenExited;
    }

    public override void _Process(double delta) {
        var position = Position;
        position.X -= _scrollSpeed * (float)delta;
        Position = position;
    }

    private void OnScreenExited() {
        QueueFree();
    }
}
