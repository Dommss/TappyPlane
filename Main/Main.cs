using Godot;
using System;

public partial class Main : Control
{
    public override void _Process(double delta) {
        if (Input.IsActionJustPressed("Fly")) {
            GetNode<GameManager>("/root/GameManager").LoadGameScene();
        }
    }
}
