using Godot;
using System;
using System.Reflection.Emit;

public partial class GameOver : Node2D
{
    private string level = LevelData.Data.levelJustCompleted;
    RichTextLabel lvlNr;
    RichTextLabel hp;
    private string hpString;

    public override void _Ready()
    {
        base._Ready();
        LevelData.Data.HP -= 1;
        lvlNr = GetNode<RichTextLabel>("RichTextLabel_level");
        lvlNr.Text = level;

        hp = GetNode<RichTextLabel>("RichTextLabel_actual");
        hpString = Convert.ToString(LevelData.Data.HP);
        hp.Text = hpString;
    }

    public override void _Process(double delta)
    {
        base._Process(delta);

        if (Input.IsKeyPressed(Key.Space) || Input.IsKeyPressed(Key.Enter))
        {
            GetTree().ChangeSceneToFile($"res://Levels/0{level}/Level{level}.tscn");
        }
        if (Input.IsKeyPressed(Key.Escape) || Input.IsKeyPressed(Key.Backspace) || Input.IsKeyPressed(Key.Delete))
        {
            GetTree().Quit();
        }
    }
}
