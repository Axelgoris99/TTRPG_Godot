using Godot;
using System;

[GlobalClass]
public partial class EnemyData : Resource
{
    [Export]
    public string name;
    [Export]
    public int hp;
    [Export]
    public int hitCount;
    [Export]
    public int damage;
    [Export]
    public int agility;
    [Export]
    public int xp;
    [Export]
    public int gold;
    public void Load(string line)
    {
        string[] elements = line.Split(',');
        name = elements[0];
        hp = Convert.ToInt32(elements[1]);
        hitCount = Convert.ToInt32(elements[2]);
        damage = Convert.ToInt32(elements[3]);
        agility = Convert.ToInt32(elements[4]);
        xp = Convert.ToInt32(elements[5]);
        gold = Convert.ToInt32(elements[6]);
    }
}
