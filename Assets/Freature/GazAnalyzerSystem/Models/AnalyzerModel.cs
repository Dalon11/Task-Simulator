using System;

[Serializable]
public class AnalyzerModel : IAnalyzerModel
{
    public float _powerToggleTime = 3f;

    public float PowerToggleTime => _powerToggleTime;
    public float NearestDistance { get; set; }
}
