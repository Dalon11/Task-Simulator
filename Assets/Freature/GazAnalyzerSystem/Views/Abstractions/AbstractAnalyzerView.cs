using UnityEngine;

public abstract class AbstractAnalyzerView : MonoBehaviour, IAnalyzerView
{
    public abstract void HideDisplayImage();
    public abstract void HideDisplayText();
    public abstract void PowerOff();
    public abstract void PowerOn();
    public abstract void ShowDisplayImage();
    public abstract void ShowDisplayText();
    public abstract void UpdateDistanceText(float distance);
    public abstract void UpdatePowerOff(float delta);
    public abstract void UpdatePowerOn(float delta);
}