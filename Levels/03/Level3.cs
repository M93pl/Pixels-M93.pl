using Godot;
using System;
using System.Reflection.Emit;
using System.Threading.Tasks;

public partial class Level3 : Node2D
{
    private CharacterBody2dEnemy3 enemy;
    private CharacterBody2dPlayer3 player;
    private CharacterBody2D exit;
    private string collider;


    public override void _Ready()
    {
        base._Ready();

        enemy = GetNode<CharacterBody2dEnemy3>("CharacterBody2D_enemy");
        player = GetNode<CharacterBody2dPlayer3>("CharacterBody2D_player");
        exit = GetNode<CharacterBody2D>("CharacterBody2D_exit");

    }
    public override void _Process(double delta)
    {
        base._Process(delta);


    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        

        for (int i=0; i< player.GetSlideCollisionCount(); i++)
        {
            var x = player.GetSlideCollision(i);
            collider = ((Node2D)x.GetCollider()).Name;
        }
        if (collider == "CharacterBody2D_enemy")
        {
            if (LevelData.Data.HP != 1)
            {
                LevelData.Data.levelJustCompleted = "3";
                GetTree().ChangeSceneToFile("res://GameOver.tscn");
            }
            else if (LevelData.Data.HP == 1)
            {
                GetTree().ChangeSceneToFile("res://HpOver.tscn");
            }
        }
        else if (collider == "CharacterBody2D_exit")
        {
            LevelData.Data.levelNext = "4";
            GetTree().ChangeSceneToFile("res://LevelBreak.tscn");
        }





        if (Input.IsKeyPressed(Key.Escape) || Input.IsKeyPressed(Key.Backspace) || Input.IsKeyPressed(Key.Delete))
        {
            GetTree().Quit();
        }
    }


}
