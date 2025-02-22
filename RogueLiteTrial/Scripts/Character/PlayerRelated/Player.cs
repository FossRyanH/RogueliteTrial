using Godot;
using System;

public partial class Player : Statemachine
{
    #region Input Resource
    [Export] public PlayerInputRes PlayerInputs { get; private set; }
    #endregion

    #region Required Nodes
    [ExportGroup("Required Nodes")]
    [Export] public CharacterRig PlayerRig { get; private set; }
    [Export] public PackedScene CameraScene { get; private set; }
    #endregion

    #region Misc For Now
    public Vector2 InputDir { get; set; }
    public Vector2 LastInputDir { get; set; }
    #endregion

    public override void _Ready()
    {
        InitializeState(new PlayerIdleState(this));

        CameraManager.Instance.AssignToPlayer(this, CameraScene);
    }
}
