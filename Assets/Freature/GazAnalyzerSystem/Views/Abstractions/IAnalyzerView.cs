public interface IAnalyzerView
{
    public void HideDisplayImage();
    public void HideDisplayText();
    public void PowerOff();
    public void PowerOn();
    public void ShowDisplayImage();
    public void ShowDisplayText();
    public void UpdateDistanceText(float distance);
    public void UpdatePowerOff(float delta);
    public void UpdatePowerOn(float delta);
}
