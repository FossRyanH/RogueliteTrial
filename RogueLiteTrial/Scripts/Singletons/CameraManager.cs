using Godot;
using System;

public partial class CameraManager : Singleton<CameraManager>
{
    Camera2D _cameraInstance;

    public void AssignToPlayer(Player player, PackedScene cameraScene)
    {
        if (_cameraInstance != null)
        {
            // Remove any existing Cameras.
            _cameraInstance.QueueFree();
        }

        _cameraInstance = cameraScene.Instantiate<Camera2D>();

        player.AddChild(_cameraInstance);

        _cameraInstance.Position = Vector2.Zero;
        _cameraInstance.MakeCurrent();
    }
}
