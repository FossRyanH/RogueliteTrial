using Godot;
using System;

public partial class PlayerInfo : Control
{
    #region Required Nodes
    [Export] ProgressBar _healthBar;
    [Export] ProgressBar _manaBar;
    [Export] Label _hpText;
    [Export] Label _manaText;
    #endregion

    #region Stat Values
    [Export] public int MaxHealth = 100;
    public int CurrentHealth { get; set; }
    [Export] public int MaxMana = 75;
    public int CurrentMana { get; set; }
    #endregion

    public override void _Ready()
    {
        CurrentHealth = MaxHealth;
        CurrentMana = MaxMana;

        SetHealth();
        SetMana();
    }

    public void SetHealth()
    {
        _hpText.Text = $"{CurrentHealth} / {MaxHealth}";
        _healthBar.Value = (MaxHealth / CurrentHealth) * 100;
    }

    public void SetMana()
    {
        _manaText.Text = $"{CurrentMana} / {MaxMana}";
        _manaBar.Value = (MaxMana / CurrentMana) * 100;

    }
}
