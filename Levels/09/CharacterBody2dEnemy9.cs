using Godot;
using System;

public partial class CharacterBody2dEnemy9 : CharacterBody2D
{
    private float speed = 90;
    private CharacterBody2dPlayer9 playerBody;
    private Vector2 playerPosition;
    private bool playerOn;
    private NavigationAgent2D agent;

    public override void _Ready()
    {
        base._Ready();
        playerBody = GetNode<CharacterBody2dPlayer9>("../CharacterBody2D_player");
        agent = GetNode<NavigationAgent2D>("NavigationAgent2D");
        agent.PathDesiredDistance = 4;
        agent.TargetDesiredDistance = 4;
        agent.Velocity = Vector2.Zero;
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);

        playerPosition = playerBody.Position;

        if (playerPosition.Y > 50 || playerPosition.X > 350 || playerPosition.X < 250)
        {
            playerOn = true;
        }

        if (playerOn)
        {
            agent.TargetPosition = playerBody.GlobalPosition;
        }
        else
        {
            agent.TargetPosition = GlobalPosition;
        }

        Vector2 desiredVelocity = Vector2.Zero;

        if (!agent.IsNavigationFinished())
        {
            Vector2 nextPathPos = agent.GetNextPathPosition();
            desiredVelocity = (nextPathPos - GlobalPosition).Normalized() * speed;
        }

        agent.Velocity = desiredVelocity;

        Velocity = agent.Velocity;

        MoveAndSlide();

    }
}
