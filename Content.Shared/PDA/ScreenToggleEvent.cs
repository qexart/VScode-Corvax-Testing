namespace Content.Shared.PDA;

public sealed class ScreenToggleEvent(bool isAc) : EntityEventArgs
{
    public bool IsAc = isAc;
}
