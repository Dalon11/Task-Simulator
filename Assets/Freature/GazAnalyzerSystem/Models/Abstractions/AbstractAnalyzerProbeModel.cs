using System.Collections.Generic;
using UnityEngine;
 
public abstract class AbstractAnalyzerProbeModel : ScriptableObject
{
    public abstract string DangerZoneTag { get; }
    public abstract List<Transform> DangerZones { get; }
}