using Godot;
using System;

[GlobalClass]
public partial class Statemachine : CharacterBody2D
{
    public event Action<IState> StateChanged;

    public IState CurrentState { get; private set; }

    protected void InitializeState(IState firstState)
    {
        if (CurrentState != null) return;

        CurrentState = firstState;
        firstState.Enter();

        StateChanged?.Invoke(firstState);
    }

    public void ChangeState(IState nextState)
    {
        if (CurrentState == null) return;

        CurrentState.Exit();
        CurrentState = nextState;
        nextState.Enter();

        StateChanged?.Invoke(nextState);
    }

    public override void _Process(double delta)
    {
        CurrentState.Update(delta);
    }

    public override void _PhysicsProcess(double delta)
    {
        CurrentState.PhysicsUpdate(delta);
    }
}
