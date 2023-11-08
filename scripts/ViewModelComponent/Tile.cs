using Godot;
using System;

[Tool]
public partial class Tile : Node3D
{
    [Export]
    public const float stepHeight = 0.25f;
    [Export]
    public Vector2I pos;
    [Export]
    public int height;

    public Vector3 center { get { return new Vector3(pos.X, height * stepHeight, pos.Y); } }

    void Match()
    {
        Position = new Vector3(pos.X, height * stepHeight / 2.0f, pos.Y);
        Scale = new Vector3(1, height * stepHeight, 1);
    }
    public void Grow()
    {
        height++;
        Match();
    }
    public void Shrink()
    {
        height--;
        Match();
    }

    public void Load(Vector2I p, int h)
    {
        pos = p;
        height = h;
        Match();
    }

    public void Load(Vector3 v)
    {
        Load(new Vector2I((int)v.X, (int)v.Z), (int)v.Y);
    }
}
