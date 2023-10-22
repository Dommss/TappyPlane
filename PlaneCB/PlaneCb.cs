using Godot;

public partial class PlaneCb : CharacterBody2D {
    private const float Gravity = 1900f;
    private const float Power = -400f;
    public override void _PhysicsProcess(double delta) {
        Vector2 velocity = Velocity;
        velocity.Y += Gravity * (float)delta;

        if (Input.IsActionJustPressed("Fly")) {
            velocity.Y = Power;
        }

        Velocity = velocity;
        MoveAndSlide();
    }
}
