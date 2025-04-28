using Godot;
using System;
using System.Reflection.Emit;
using System.Threading.Tasks;

public partial class Level9 : Node2D
{
    private CharacterBody2dEnemy9 enemy;
    private CharacterBody2dPlayer9 player;
    private Area2D playerArea;
    private CharacterBody2D exit;
    private string collider;
    private string colliderEvent;


    public override void _Ready()
    {
        base._Ready();
        enemy = GetNode<CharacterBody2dEnemy9>("CharacterBody2D_enemy");
        player = GetNode<CharacterBody2dPlayer9>("CharacterBody2D_player");
        exit = GetNode<CharacterBody2D>("CharacterBody2D_exit");
        playerArea = GetNode<Area2D>("CharacterBody2D_player/Area2D_player");
        playerArea.BodyShapeEntered += CollisionEvent;
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
            || collider == "CharacterBody2D_enemy4" || collider == "CharacterBody2D_enemy5" || collider == "CharacterBody2D_enemy6" || collider == "CharacterBody2D_enemy7"
            || colliderEvent == "CharacterBody2D_enemy" || colliderEvent == "CharacterBody2D_enemy2" || colliderEvent == "CharacterBody2D_enemy3"
            || colliderEvent == "CharacterBody2D_enemy4" || colliderEvent == "CharacterBody2D_enemy5" || colliderEvent == "CharacterBody2D_enemy6" || colliderEvent == "CharacterBody2D_enemy7")
        {
            if (LevelData.Data.HP != 1)
            {
                LevelData.Data.levelJustCompleted = "9";
                GetTree().ChangeSceneToFile("res://GameOver.tscn");
            }
            else if (LevelData.Data.HP == 1)
            {
                GetTree().ChangeSceneToFile("res://HpOver.tscn");
            }
        }
        else if (collider == "CharacterBody2D_exit" || colliderEvent == "CharacterBody2D_exit")
        {
            LevelData.Data.levelNext = "9";
            GetTree().ChangeSceneToFile("res://GameWin.tscn");
        }

        



        if (Input.IsKeyPressed(Key.Escape) || Input.IsKeyPressed(Key.Backspace) || Input.IsKeyPressed(Key.Delete))
        {
            GetTree().Quit();
        }
    }
    private void CollisionEvent(Rid bodyRid, Node2D body, long bodyShapeIndex, long localShapeIndex)

    {
        colliderEvent = body.Name;
    }

}
