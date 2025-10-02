using UnityEngine;

public abstract class AbstractAnalyzerModel : ScriptableObject, IAnalyzerModel
{
    public abstract float PowerToggleTime { get; }
    public abstract float NearestDistance { get; set; }
}