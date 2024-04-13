using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PassButton : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent Click;
    public void OnPointerClick(PointerEventData eventData)
    {
        Click?.Invoke();
    }
}
