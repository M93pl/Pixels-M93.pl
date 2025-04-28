using Godot;
using System;
//level1
public partial class CharacterBody2dPlayer : CharacterBody2D
{
    private float speed = 100;
    public override void _Ready()
    {
        base._Ready();






    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        Velocity = new Vector2(0, 0);
        float X = 0;
        float Y = 0;

        if (Input.IsKeyPressed(Key.W))
        {
            Y -= speed;
        }
        if (Input.IsKeyPressed(Key.S))
        {
            Y += speed;
        }
        if (Input.IsKeyPressed(Key.A))
        {
            X -= speed;
        }
        if (Input.IsKeyPressed(Key.D))
        {
            X += speed;
        }
        Velocity = new Vector2(X, Y);

        MoveAndSlide();




    }
}
