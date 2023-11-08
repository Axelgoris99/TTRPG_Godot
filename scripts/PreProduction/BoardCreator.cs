using System.Collections.Generic;
using Godot;
[Tool]
public partial class BoardCreator : Node
{
    [Export]
    PackedScene tileViewPrefab;
    [Export]
    PackedScene tileSelectionIndicatorPrefab;

    Node3D marker
    {
        get
        {
            if (_marker == null)
            {
                Node3D instance = tileSelectionIndicatorPrefab.Instantiate() as Node3D;
                _marker = instance;
            }
            return _marker;
        }
    }
    Node3D _marker;
    Dictionary<Vector2I, Tile> tiles = new Dictionary<Vector2I, Tile>();
    [Export]
    int width = 10;
    [Export]

    int depth = 10;
    [Export]

    int height = 8;
    [Export]
    Vector2I pos;
    [Export]
    LevelData levelData;
    public void GrowArea()
    {
        Rect2I r = RandomRect();
        GrowRect(r);
    }
    public void ShrinkArea()
    {
        Rect2I r = RandomRect();
        ShrinkRect(r);
    }

    Rect2I RandomRect()
    {
        int x = GD.RandRange(0, width);
        int y = GD.RandRange(0, depth);
        int w = GD.RandRange(1, width - x + 1);
        int h = GD.RandRange(0, depth - y + 1);
        return new Rect2I(x, y, w, h);
    }
    void GrowRect(Rect2I rect)
    {
        for (int y = rect.Position.Y; y < rect.End.Y; ++y)
        {
            for (int x = rect.Position.X; x < rect.End.X; ++x)
            {
                Vector2I p = new Vector2I(x, y);
                GrowSingle(p);
            }
        }
    }
    void ShrinkRect(Rect2I rect)
    {
        for (int y = rect.Position.Y; y < rect.End.Y; ++y)
        {
            for (int x = rect.Position.X; x < rect.End.X; ++x)
            {
                Vector2I p = new Vector2I(x, y);
                ShrinkSingle(p);
            }
        }
    }

    Tile Create()
    {
        if (tileViewPrefab == null)
        {
            tileViewPrefab = GD.Load<PackedScene>("res://prefab/Tile.tscn");
        }
        Tile tile = tileViewPrefab.Instantiate() as Tile;
        AddChild(tile);
        // Necessary, otherwise you will see it in the editor view but not in the hierarchy because it does not belong to the scene...
        // This basically add the object as a child IN the inspector and not only in the code.
        tile.Owner = this;
        return tile;
    }
    Tile GetOrCreate(Vector2I p)
    {
        if (tiles.ContainsKey(p))
            return tiles[p];

        Tile t = Create();
        t.Load(p, 0);
        tiles.Add(p, t);
        t.Name = "Tile " + p.ToString();

        return t;
    }
    void GrowSingle(Vector2I p)
    {
        Tile t = GetOrCreate(p);
        if (t.height < height)
            t.Grow();
    }
    void ShrinkSingle(Vector2I p)
    {
        if (!tiles.ContainsKey(p))
            return;

        Tile t = tiles[p];
        t.Shrink();

        if (t.height <= 0)
        {
            tiles.Remove(p);
            t.Free();
        }
    }

    public void Grow()
    {
        GrowSingle(pos);
    }
    public void Shrink()
    {
        ShrinkSingle(pos);
    }

    public void UpdateMarker()
    {
        Tile t = tiles.ContainsKey(pos) ? tiles[pos] : null;
        marker.Position = t != null ? t.center : new Vector3(pos.X, 0, pos.Y);
    }

    public void Clear()
    {

        foreach (var child in GetChildren())
        {
            child.Free();
        }
        tiles.Clear();
    }

    public void Save()
    {
        string filePath = "res://import/levels/level";
        LevelData board = new LevelData();
        board.tiles = new Godot.Collections.Array<Vector3>();
        foreach (Tile t in tiles.Values)
            board.tiles.Add(new Vector3(t.pos.X, t.height, t.pos.Y));
        string fileName = string.Format("{0}.tres", filePath);

        ResourceSaver.Save(board, fileName);
        // Necessary otherwise, the cache is used and the file will not be the right one in the inspector. (But will be on next launch...)
        board.TakeOverPath(fileName);
    }
    public void Load()
    {
        Clear();
        if (levelData == null)
            return;
        foreach (Vector3 v in levelData.tiles)
        {
            Tile t = Create();
            t.Load(v);
            tiles.Add(t.pos, t);
        }
    }
}