using Godot;
using System;

public partial class CharacterBody2dEnemy : CharacterBody2D
{
    private float speed = 50;
    private CharacterBody2dPlayer playerBody;
    private Vector2 playerPosition;


    public override void _Ready()
    {
        base._Ready();
        playerBody = GetNode<CharacterBody2dPlayer>("../CharacterBody2D_player");
        



    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);

        playerPosition = playerBody.Position;

        if (playerPosition.Y > 280) 
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
        Vector2 newMove = new Vector2 (0,0);

        if (p.X > Position.X)
        {
            newMove.X +=1;
        }
        if (p.X < Position.X)
        {
            newMove.X -=1;
        }
        if (p.X == Position.X)
        {
            newMove.X = 0;
        }
        if (p.Y > Position.Y)
        {
            newMove.Y +=1;
        }
        if (p.Y < Position.Y)
        {
            newMove.Y -=1;
        }
        if (p.Y == Position.Y)
        {
            newMove.Y = 0;
        }

        return newMove;
    }

}
