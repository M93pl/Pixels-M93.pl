using Godot;
using System;

public partial class LevelData : Node
{
    public static LevelData Data { get; private set; }
    public string levelJustCompleted { get; set; }
    public string levelNext { get; set; }
    public int HP { get; set; }

    public override void _Ready()
    {
        base._Ready();
        Data = this;
        HP = 1;
    }


}
