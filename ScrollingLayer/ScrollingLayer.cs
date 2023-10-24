using Godot;
using System;
using System.Net.Mime;

public partial class ScrollingLayer : ParallaxLayer {
    [Export] private Texture2D _texture;
    [Export] private float _scrollSpeed;
    [Export] private float _txX = 1920f;
    [Export] private float _txY = 1080f;

    private Sprite2D _sprite;

    public override void _Ready() {
        _sprite = GetNode<Sprite2D>("Sprite2D");
        var motionScale = MotionScale;
        motionScale.X = -(_scrollSpeed);
        MotionScale = motionScale;

        var scaleFactor = GetViewportRect().Size.Y / _txY;

        _sprite.Texture = _texture;
        _sprite.Scale = new Vector2(scaleFactor, scaleFactor);

        var motionMirroring = MotionMirroring;
        motionMirroring.X = _txX * scaleFactor;
        MotionMirroring = motionMirroring;
    }
}
