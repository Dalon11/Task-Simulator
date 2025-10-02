using System;

public class GazAnalyzerButtonInput : AbstractGazAnalyzerButtonInput
{
    public override event Action<bool> onPowerButton = (_) =>{};

    public void OnStartPowerButton() => onPowerButton.Invoke(true);

    public void OnEndPowerButton() => onPowerButton.Invoke(false);
}
