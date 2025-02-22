using Godot;
using System;

public partial class PlayerFollowCamera : Camera2D
{
	[Export] float _smoothSpeed = 5f;

	Player _player;

    public override void _Ready()
    {
        var localPlayers = GetTree().GetNodesInGroup("Players");

		if (localPlayers.Count > 0)
		{
			foreach (var player in localPlayers)
			{
				var playerNode = player as Player;

				if (playerNode != null && !HasCameraAttached(playerNode))
				{
					_player = playerNode;
					break;
				}
			}
		}

		if (_player == null)
		{
			GD.PrintErr("No viable player found...");
		}

        Zoom = new(4, 4);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(double delta)
	{
		if (_player == null) return;

		Vector2 currentPos = GlobalPosition;

		Vector2 targetPos = _player.GlobalPosition;

		Vector2 newPos = currentPos.Lerp(targetPos, _smoothSpeed * (float)delta);

		GlobalPosition = newPos;
	}

	bool HasCameraAttached(Player player)
	{
		return player.GetNodeOrNull<Camera2D>(nameof(player.CameraScene)) != null;
	}
}
