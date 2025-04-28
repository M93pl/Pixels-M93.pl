using Godot;
using System;

public partial class CharacterBody2dEnemy8 : CharacterBody2D
{
    private float speed = 75;
    private CharacterBody2dPlayer8 playerBody;
    private Vector2 playerPosition;
    private bool playerOn;
    private KinematicCollision2D colision;

    public override void _Ready()
    {
        base._Ready();
        playerBody = GetNode<CharacterBody2dPlayer8>("../CharacterBody2D_player");

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



        // omijanie przeszkód
        colision = GetLastSlideCollision();
        if(colision != null)
        { 
            string collider = ((Node2D)colision.GetCollider()).Name;
            if(collider.Length>12)
            {char x = collider[12];
                if (x == '_')
                {
                    Velocity = new Vector2(1, 0) * speed;
                }
            }
            
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
