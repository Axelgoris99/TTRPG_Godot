using Godot;
using System;

public partial class Demo : Node
{
    public override void _Ready()
    {
        EnemyData enemyData = GD.Load<EnemyData>("res://import/enemies/GARLAND.tres");
        GD.Print(enemyData.name);
        GD.Print(enemyData.hp);
        enemyData = null;
    }
}
