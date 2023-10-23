using Godot;

public partial class PlaneCb : CharacterBody2D {
    // [Signal] public delegate void PlaneDiedEventHandler();
    
    private const float Gravity = 1900f;
    private const float Power = -400f;

    private GameManager _gameManager;
    
    private AnimatedSprite2D _animatedSprite;
    private AnimationPlayer _animationPlayer;

    private bool _isDead = false;

    public override void _Ready() {
        _gameManager = GetNode<GameManager>("/root/GameManager");
        _animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        _animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        _gameManager.PlaneCrashed += Die;
    }

    public override void _PhysicsProcess(double delta) {
        Fly(delta);

        if (IsOnFloor()) {
            Die();
        }
}

    private void Die() {
        if (_isDead) return;

        _isDead = true;
        _animatedSprite.Stop();
        _gameManager.EmitSignal(GameManager.SignalName.GameOver);
        SetPhysicsProcess(false);
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
