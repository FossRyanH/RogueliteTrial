using Godot;
using System;

public partial class InputManager : Singleton<InputManager>
{
    [Export] PlayerInputRes _playerInputs;
    Vector2 _inputDir;

    public override void _Input(InputEvent @event)
    {
        _inputDir = Input.GetVector("MoveLeft", "MoveRight", "MoveUp", "MoveDown");

        _playerInputs.HandleMovement(_inputDir != Vector2.Zero ? _inputDir : Vector2.Zero);

        if (@event.IsActionPressed("Attack"))
        {
            _playerInputs.HandleAttack();
        }
        else if (@event.IsActionPressed("Interact"))
        {
            _playerInputs.HandleInteract();
        }
    }
}
