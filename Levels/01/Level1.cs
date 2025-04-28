using Godot;
using System;
using System.Reflection.Emit;
using System.Threading.Tasks;

public partial class Level1 : Node2D
{
    private bool playerMoved = false;
    private bool enemyMoved = false;
    private bool preesed = false;
    private RichTextLabel label1;
    private RichTextLabel label2;
    private RichTextLabel label3;
    private CharacterBody2dEnemy enemy;
    private CharacterBody2dPlayer player;
    private CharacterBody2D exit;
    private Vector2 oldPos;
    private Timer timer;
    private Timer timer2;
    private bool timerRunning = true;
    private bool timerRunning2 = true;
    private string collider;


    public override void _Ready()
    {
        base._Ready();

        label1 = GetNode<RichTextLabel>("RichTextLabel");
        label2 = GetNode<RichTextLabel>("RichTextLabel2");
        label3 = GetNode<RichTextLabel>("RichTextLabel3");
        enemy = GetNode<CharacterBody2dEnemy>("CharacterBody2D_enemy");
        player = GetNode<CharacterBody2dPlayer>("CharacterBody2D_player");
        exit = GetNode<CharacterBody2D>("CharacterBody2D_exit");

        timer = GetNode<Timer>("Timer");
        timer2 = GetNode<Timer>("Timer2");

        oldPos = enemy.Position;
        label2.Visible = false;
        label3.Visible = false;

        timer.WaitTime = 2;
        timer.Timeout += TimerOut;
        timer2.WaitTime = 1.2;
        timer2.Timeout += TimerOut2;
    }
    public override void _Process(double delta)
    {
        base._Process(delta);


    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        

        if (Input.IsKeyPressed(Key.W) || Input.IsKeyPressed(Key.S) || Input.IsKeyPressed(Key.A) || Input.IsKeyPressed(Key.D))
        {
            preesed = true;
        }

        if (preesed == true)
        {
            TimerStart();
            timerRunning = false;
        }

        if (enemy.Position != oldPos)
        {
            timer.Stop();
            TimerStart2();
            timerRunning2 = false;
            preesed = false;

        }

        for (int i=0; i< player.GetSlideCollisionCount(); i++)
        {
            var x = player.GetSlideCollision(i);
            collider = ((Node2D)x.GetCollider()).Name;
        }
        if (collider == "CharacterBody2D_enemy")
        {
            if (LevelData.Data.HP != 1)
            {
                LevelData.Data.levelJustCompleted = "1";
                GetTree().ChangeSceneToFile("res://GameOver.tscn");
            }
            else if(LevelData.Data.HP == 1)
            {   
                GetTree().ChangeSceneToFile("res://HpOver.tscn");
            }
        }
        else if (collider == "CharacterBody2D_exit")
        {
            LevelData.Data.levelNext = "2";
            GetTree().ChangeSceneToFile("res://LevelBreak.tscn");
        }





        if (Input.IsKeyPressed(Key.Escape) || Input.IsKeyPressed(Key.Backspace) || Input.IsKeyPressed(Key.Delete))
        {
            GetTree().Quit();
        }
    }


    private void TimerStart()
    {
        if (timerRunning == true) timer.Start();
    }
    private void TimerStart2()
    {
        if (timerRunning2 == true) timer2.Start();
    }

    private void TimerOut()
    {
        label1.Visible = false;
        label2.Visible = true;
    }
    private void TimerOut2()
    {
        label1.Visible = false;
        label2.Visible = false;
        label3.Visible = true;
    }
}
