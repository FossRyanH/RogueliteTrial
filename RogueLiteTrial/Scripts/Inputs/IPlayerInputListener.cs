using Godot;
using System;

public interface IPlayerInputListener
{
    void Move(Vector2 move);
    void Attack();
    void Interact();
    void ToggleMenu();
    void ToggleInventory();
}
