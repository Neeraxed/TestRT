using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PassButton : MonoBehaviour
{
    public UnityEvent Click;
    private void OnMouseDown()
    {
        if(PasscodeTaskManager.Instance.IsRunning)
            Click?.Invoke();
    }
}
