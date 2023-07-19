using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour,IPointerDownHandler,IPointerUpHandler,IDragHandler
{
    private Vector2 _touchPosition;
    public Vector2 InputDirection { get; private set; }

    public void OnPointerDown(PointerEventData eventData)
    {
        _touchPosition = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        InputDirection = Vector2.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        var inputDelta = eventData.position - _touchPosition;
        InputDirection = inputDelta.normalized;
    }
}
