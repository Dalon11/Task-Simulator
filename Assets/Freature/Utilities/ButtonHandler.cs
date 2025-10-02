using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [Header("Events")]
    public UnityEvent OnPressStart;
    public UnityEvent OnPressEnd;
    [Space]
    [SerializeField] private KeyCode _keyCode;

    private void Update() => CheckGetKey();

    public void OnPointerDown(PointerEventData eventData) => OnPressStart?.Invoke();

    public void OnPointerUp(PointerEventData eventData) => OnPressEnd?.Invoke();

    private void CheckGetKey()
    {
        if (Input.GetKeyDown(_keyCode))
            OnPointerDown(null);

        if (Input.GetKeyUp(_keyCode))
            OnPointerUp(null);
    }
}