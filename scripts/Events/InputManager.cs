using Godot;
using System;
using System.Collections;

public partial class InputManager : Node
{
    class Repeater
    {
        const float threshold = 500f;
        float _next;
        bool _hold;
        string _eventListened;
        InputEventAction _eventFired;

        public Repeater(string eventListened, string eventFired)
        {
            _eventListened = eventListened;
            _eventFired = new InputEventAction
            {
                Action = eventFired,
                Pressed = true
            };
        }

        public void Activate()
        {
            _hold = true;
        }
        public void Update()
        {
            if (!_hold) return;
            // Polling the action
            bool value = Input.IsActionPressed(_eventListened);
            if (value)
            {
                if (Time.GetTicksMsec() > _next)
                {
                    _next = Time.GetTicksMsec() + threshold;
                    Input.ParseInputEvent(_eventFired);
                }
            }
            else
            {
                _hold = false;
                _next = 0;
            }
        }
    }

    Repeater upRepeater;


    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("Up"))
        {
            GD.Print("Up occurred!");
            upRepeater.Activate();
        }
        if (@event.IsActionPressed("UpRepeat"))
        {
            GD.Print("Up Repeat occurred!");
        }
    }

    public override void _Ready()
    {
        upRepeater = new Repeater("Up", "UpRepeat");
    }
    public override void _Process(double delta)
    {
        upRepeater.Update();
    }
}
