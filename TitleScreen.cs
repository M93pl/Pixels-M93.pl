using Godot;
using System;

public partial class TitleScreen : Node2D
{
    public override void _Ready()
    {
        base._Ready();

        LevelData.Data.HP = 1;
    }

    public override void _Process(double delta)
    {
        base._Process(delta);


        if (Input.IsKeyPressed(Key.Space) || Input.IsKeyPressed(Key.Enter))
        {
            GetTree().ChangeSceneToFile("res://Levels/01/Level1.tscn");
        }
        if (Input.IsKeyPressed(Key.T))
        {
            GetTree().ChangeSceneToFile("res://Tutorial.tscn");
        }
        if (Input.IsKeyPressed(Key.Escape) || Input.IsKeyPressed(Key.Backspace) || Input.IsKeyPressed(Key.Delete))
        {
            GetTree().Quit();
        }
    }



}
