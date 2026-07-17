using Godot;
using System;

namespace Game.Core;

public partial class StateMachine : Node
{
  [ExportCategory("State Machine Vars")]
  [Export] public Node Customer;
  [Export] public State CurrentState;

	public override void _Ready()
  {
    foreach (Node child in GetChildren())
    {
      if (child is State state)
      {
        state.Owner = Customer;
        state.SetProcess(false);
      }
    }
  }

  public string GetCurrentState()
  {
    return CurrentState.Name.ToString();
  }

  public void ChangeState(State newState)
  {
    CurrentState?.ExitState();
    CurrentState = newState;
    CurrentState?.EnterState();

    foreach (Node child in GetChildren())
    {
      if (child is State state)
      {
        state.SetProcess(child == CurrentState);
      }
    } 
  }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
