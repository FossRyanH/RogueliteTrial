using Godot;
using System;

public partial class PlayerMoveState : PlayerBaseState
{
    Vector2 _velocity;

    public PlayerMoveState(Player player) : base(player)
    {
    }

    public override void Enter()
    {
        base.Enter();

        AnimTreeName = "MoveTree";
        Travel(AnimTreeName);
    }

    public override void Update(double delta)
    {
        base.Update(delta);

        if (Player.InputDir.IsZeroApprox())
        {
            Player.ChangeState(new PlayerIdleState(Player));
        }
    }

    public override void PhysicsUpdate(double delta)
    {
        _velocity = Player.InputDir * 75f;
        Player.Velocity = _velocity;

        Player.MoveAndSlide();
    }
}