using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(AnalyzerProbeModel), menuName = "Models/" + nameof(AnalyzerProbeModel))]
public class AnalyzerProbeModel : ScriptableObject
{
    [SerializeField] private string _dangerZoneTag = "DangerZone";

    private readonly List<Transform> _dangerZones = new List<Transform>();

    public string DangerZoneTag => _dangerZoneTag;

    public List<Transform> DangerZones => _dangerZones;

    private void OnEnable() => _dangerZones.Clear();
}
