using Godot;
using System;

[GlobalClass]
public partial class PlayerInputRes : Resource
{
    public event Action<Vector2> Movement;
    public event Action Attack, Interact, ToggleInventory, ToggleMenu;

    public void HandleMovement(Vector2 movement) => Movement?.Invoke(movement);
    public void HandleAttack() => Attack?.Invoke();
    public void HandleInteract() => Interact?.Invoke();
    public void HandleInventoryToggle() => ToggleInventory?.Invoke();
    public void HandleMenuToggle() => ToggleMenu?.Invoke();
}
