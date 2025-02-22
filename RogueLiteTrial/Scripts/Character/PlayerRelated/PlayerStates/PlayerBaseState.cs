using Godot;
using System;

public class PlayerBaseState : IState, IPlayerInputListener
{
    protected Player Player;
    protected string AnimTreeName;

    public PlayerBaseState(Player player)
    {
        Player = player;
    }

    public virtual void Enter()
    {
        RegisterListeners();
    }

    public virtual void Exit()
    {
        UnregisterListeners();
    }

    public virtual void PhysicsUpdate(double delta) {}



    public virtual void Update(double delta) 
    {
        UpdateLookDir();
    }

    void RegisterListeners() 
    {
        Player.PlayerInputs.Movement += Move;
        Player.PlayerInputs.Interact += Interact;
        Player.PlayerInputs.Attack += Attack;
    }

    void UnregisterListeners() 
    {
        Player.PlayerInputs.Movement -= Move;
        Player.PlayerInputs.Interact -= Interact;
        Player.PlayerInputs.Attack -= Attack;
    }

    public void Attack()
    {
        GD.Print("Attacking");
    }

    public void ToggleMenu()
    {
        // 
    }
    
    public void ToggleInventory()
    {
        // 
    }

    public void Interact()
    {
        GD.Print("Interacting");
    }

    public void Move(Vector2 move)
    {
        Player.InputDir = move;
        Player.InputDir.Normalized();

        if (Player.InputDir != Vector2.Zero)
        {
            Player.LastInputDir = Player.InputDir;
        }
    }

    protected void Travel(string animTree)
    {
        Player.PlayerRig.StatemachinePlayback.Travel(animTree);
    }

    void UpdateLookDir()
    {
        Player.PlayerRig.AnimTree.Set($"parameters/{AnimTreeName}/blend_position", Player.LastInputDir);
    }
}