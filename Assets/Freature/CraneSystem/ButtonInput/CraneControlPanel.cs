using System;
using UnityEngine;

[SelectionBase]
public class CraneControlPanel : AbstractCraneButtonInput
{
    public override event Action<bool> onUpButton = (_) => { };
    public override event Action<bool> onDownButton = (_) => { };
    public override event Action<bool> onRightButton = (_) => { };
    public override event Action<bool> onLeftButton = (_) => { };
    public override event Action<bool> onForwardButton = (_) => { };
    public override event Action<bool> onBackButton = (_) => { };

    public void OnStartUpButton() => onUpButton.Invoke(true);

    public void OnEndUpButton() => onUpButton.Invoke(false);

    public void OnStartDownButton() => onDownButton.Invoke(true);

    public void OnEndDownButton() => onDownButton.Invoke(false);

    public void OnStartRightButton() => onRightButton.Invoke(true);

    public void OnEndRightButton() => onRightButton.Invoke(false);

    public void OnStartLeftButton() => onLeftButton.Invoke(true);

    public void OnEndLeftButton() => onLeftButton.Invoke(false);

    public void OnStartForwardButton() => onForwardButton.Invoke(true);

    public void OnEndForwardButton() => onForwardButton.Invoke(false);

    public void OnStartBackButton() => onBackButton.Invoke(true);

    public void OnEndBackButton() => onBackButton.Invoke(false);
}