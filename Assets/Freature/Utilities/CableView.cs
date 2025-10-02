using UnityEngine;

public class CableView : MonoBehaviour
{
    [Header("Transforms")]
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;
    [Space]
    [SerializeField] private MeshRenderer _cableRenderer; 

    private void Update()
    {
        UpdateCable();
    }
     
    public void UpdateCable()
    {
        Transform cableTransform = _cableRenderer.transform;
        Vector3 startPosition = _startPoint.position;
        Vector3 endPosition = _endPoint.position;
        UpdateCablePosition(cableTransform, startPosition, endPosition);
        UpdateCableRotation(cableTransform, endPosition);
        UpdateCableScale(cableTransform, startPosition, endPosition);
    }

    private void UpdateCablePosition(Transform cable, Vector3 startPosition, Vector3 endPosition) => 
        cable.position = (startPosition + endPosition) * 0.5f;

    private void UpdateCableRotation(Transform cable, Vector3 endPosition)
    { 
        cable.LookAt(endPosition);
        cable.Rotate(90f, 0f, 0f);
    }

    private void UpdateCableScale(Transform cable, Vector3 startPosition, Vector3 endPosition)
    { 
        float distance = Vector3.Distance(startPosition, endPosition);
        cable.localScale = new Vector3(cable.localScale.x, distance * 0.5f, cable.localScale.z);
    }
}