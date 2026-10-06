using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.OnScreen;

public class VirtualJoystick : OnScreenControl, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [InputControl(layout = "Vector2")]
    [SerializeField]
    private string _controlPath;
    private int _pointerId;
    protected override string controlPathInternal { get => _controlPath; set => _controlPath = value; }
    private Vector2 _joystickOrigin;

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        if (_pointerId == pointerEventData.pointerId) return;
        _joystickOrigin = pointerEventData.position;    
        _pointerId = pointerEventData.pointerId;
    }

    public void OnDrag(PointerEventData pointerEventData)
    {
        if (_pointerId == 0) return;
        Vector2 joystickPosition = (pointerEventData.position - _joystickOrigin) / 600;
        joystickPosition = Vector2.ClampMagnitude(joystickPosition, 1.0f);
        SendValueToControl(joystickPosition);
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        _pointerId = 0;
        _joystickOrigin = Vector2.zero;
        SendValueToControl(Vector2.zero);
    }
}
