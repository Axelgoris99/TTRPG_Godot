// RandomIntEditor.cs
#if TOOLS
using Godot;
[Tool]

public partial class BoardInspectorEditor : BoxContainer
{
    // The main control for editing the property.
    private Button clear = new Button() { Text = "Clear Level" };
    private Button grow = new Button() { Text = "Grow Level" };
    private Button shrink = new Button() { Text = "Shrink Level" };
    private Button growArea = new Button() { Text = "Grow Area" };
    private Button shrinkArea = new Button() { Text = "Shrink Area" };
    private Button save = new Button() { Text = "Save Level" };
    private Button load = new Button() { Text = "Load Level" };

    private BoardCreator board;
    public BoardInspectorEditor()
    {
        // Add the control as a direct child of EditorProperty node.
        AddChild(clear);
        AddChild(grow);
        AddChild(shrink);
        AddChild(growArea);
        AddChild(shrinkArea);
        AddChild(save);
        AddChild(load);

        clear.Pressed += OnClearPressed;
        grow.Pressed += OnGrowPressed;
        shrink.Pressed += OnShrinkPressed;
        growArea.Pressed += OnGrowAreaPressed;
        shrinkArea.Pressed += OnShrinkAreaPressed;
        save.Pressed += OnSavePressed;
        load.Pressed += OnLoadPressed;

        clear.Pressed += UpdateMarker;
        grow.Pressed += UpdateMarker;
        shrink.Pressed += UpdateMarker;
        growArea.Pressed += UpdateMarker;
        shrinkArea.Pressed += UpdateMarker;
        save.Pressed += UpdateMarker;
        load.Pressed += UpdateMarker;

        EditorPlugin test = new EditorPlugin();
        // This is to get the current selected node that should have the board creator script.
        board = test.GetEditorInterface().GetEditedSceneRoot() as BoardCreator;
        var newPos = test.GetEditorInterface().GetSelection().GetSelectedNodes()[0] as Tile;
        if (newPos is Tile)
        {
            board.UpdatePos(newPos.pos);
        }
    }

    private void OnClearPressed()
    {
        board.Clear();
    }

    private void OnGrowPressed()
    {
        board.Grow();
    }

    private void OnShrinkPressed()
    {
        board.Shrink();
    }

    private void OnGrowAreaPressed()
    {
        board.GrowArea();
    }

    private void OnShrinkAreaPressed()
    {
        board.ShrinkArea();
    }

    private void OnSavePressed()
    {
        board.Save();
    }

    private void OnLoadPressed()
    {
        board.Load();
    }

    private void UpdateMarker()
    {
        board.UpdateMarker();
    }
}
#endif