using Godot;
using System;

public partial class CharacterRig : Node2D
{
    #region Required Nodes
    [Export] public AnimationPlayer AnimPlayer { get; private set; }
    [Export] public AnimationTree AnimTree { get; set; }
    #endregion

    #region Misc
    public AnimationNodeStateMachinePlayback StatemachinePlayback { get; set; }
    #endregion

    public override void _Ready()
    {
        AnimTree.Active = true;
        StatemachinePlayback = (AnimationNodeStateMachinePlayback)AnimTree.Get("parameters/playback");
    }
}
