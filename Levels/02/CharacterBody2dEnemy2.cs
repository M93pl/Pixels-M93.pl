using Godot;
using System;

public partial class CharacterBody2dEnemy2 : CharacterBody2D
{
    private float speed = 80;
    private CharacterBody2dPlayer2 playerBody;
    private Vector2 playerPosition;


    public override void _Ready()
    {
        base._Ready();
        playerBody = GetNode<CharacterBody2dPlayer2>("../CharacterBody2D_player");
        



    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);

        playerPosition = playerBody.Position;

        if (playerPosition.Y > 50) 
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
