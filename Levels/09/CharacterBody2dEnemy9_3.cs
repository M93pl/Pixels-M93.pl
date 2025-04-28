using Godot;
using System;

public partial class CharacterBody2dEnemy9_3 : CharacterBody2D
{
    private float speed = 55;
    private CharacterBody2dPlayer9 playerBody;
    private Vector2 playerPosition;
    private bool playerOn;

    public override void _Ready()
    {
        base._Ready();
        playerBody = GetNode<CharacterBody2dPlayer9>("../CharacterBody2D_player");

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
            Velocity = playerSearch() * speed;
        }
        else
        {
            Velocity = new Vector2(0, 0);
        }

  
        

        MoveAndSlide();


    }

    private Vector2 playerSearch()
    {
        Vector2 p = playerPosition;
        Vector2 newMove = new Vector2(0, 0);

        if (p.X > Position.X)
        {
            newMove.X += 1;
        }
        if (p.X < Position.X)
        {
            newMove.X -= 1;
        }
        if (p.X == Position.X)
        {
            newMove.X = 0;
        }
        if (p.Y > Position.Y)
        {
            newMove.Y += 1;
        }
        if (p.Y < Position.Y)
        {
            newMove.Y -= 1;
        }
        if (p.Y == Position.Y)
        {
            newMove.Y = 0;
        }

        return newMove;
    }

}