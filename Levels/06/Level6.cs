using Godot;
using System;
using System.Reflection.Emit;
using System.Threading.Tasks;

public partial class Level6 : Node2D
{
    private CharacterBody2dEnemy6 enemy;
    private CharacterBody2dPlayer6 player;
    private CharacterBody2D exit;
    private string collider;


    public override void _Ready()
    {
        base._Ready();

        enemy = GetNode<CharacterBody2dEnemy6>("CharacterBody2D_enemy");
        player = GetNode<CharacterBody2dPlayer6>("CharacterBody2D_player");
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
        if (collider == "CharacterBody2D_enemy" || collider == "CharacterBody2D_enemy2" || collider == "CharacterBody2D_enemy3"
            || collider == "CharacterBody2D_enemy4" || collider == "CharacterBody2D_enemy5" || collider == "CharacterBody2D_enemy6")
        {
            if (LevelData.Data.HP != 1)
            {
                LevelData.Data.levelJustCompleted = "6";
                GetTree().ChangeSceneToFile("res://GameOver.tscn");
            }
            else if (LevelData.Data.HP == 1)
            {
                GetTree().ChangeSceneToFile("res://HpOver.tscn");
            }
        }
        else if (collider == "CharacterBody2D_exit")
        {
            LevelData.Data.levelNext = "7";
            GetTree().ChangeSceneToFile("res://LevelBreak.tscn");
        }

        



        if (Input.IsKeyPressed(Key.Escape) || Input.IsKeyPressed(Key.Backspace) || Input.IsKeyPressed(Key.Delete))
        {
            GetTree().Quit();
        }
    }


}
