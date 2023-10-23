using Godot;

public partial class PlaneCb : CharacterBody2D {
    private const float Gravity = 1900f;
    private const float Power = -400f;

    private AnimationPlayer _animationPlayer;

    public override void _Ready() {
        _animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
    }

    public override void _PhysicsProcess(double delta) {
        Fly(delta);
}

    private void Fly(double delta) {
        Vector2 velocity = Velocity;
        velocity.Y += Gravity * (float)delta;
        if (Input.IsActionJustPressed("Fly")) {
            velocity.Y = Power;
            _animationPlayer.Play("Fly");
        }

        Velocity = velocity;
        MoveAndSlide();
    }
}
