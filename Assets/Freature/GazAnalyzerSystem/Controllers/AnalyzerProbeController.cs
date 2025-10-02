using System.Linq;
using UnityEngine;

public class AnalyzerProbeController : MonoBehaviour
{
    [SerializeField] private Transform _probe;
    [SerializeField] private AbstractAnalyzerProbeModel _model;

    private void Start() => FindDangerZones();

    public void AddDangerZone(GameObject dangerZone) => _model.DangerZones.Add(dangerZone.transform);

    public float GetNearestDangerZoneDistance()
    {
        if (_model.DangerZones.Count == 0)
            return -1f;

        Vector3 currentPos = _probe.position;
        float nearestDistance = _model.DangerZones
            .Where(zone => zone != null && zone.gameObject.activeInHierarchy)
            .Select(zone => Vector3.Distance(currentPos, zone.transform.position))
            .OrderBy(distance => distance)
            .DefaultIfEmpty(-1f)
            .First();
        return nearestDistance;
    }

    private void FindDangerZones()
    {
        GameObject[] dangerZones = GameObject.FindGameObjectsWithTag(_model.DangerZoneTag);
        foreach (var zone in dangerZones)
            AddDangerZone(zone);
    }
}
