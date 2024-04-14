using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PassButton : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent Click;

    public void OnPointerClick(PointerEventData eventData)
    {

    }

    private void OnMouseDown()
    {
        Debug.Log("AAA");
        if (PasscodeTaskManager.Instance.IsRunning)
            Click?.Invoke();
    }
}
