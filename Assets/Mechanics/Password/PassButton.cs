using UnityEngine;
using UnityEngine.Events;

public class PassButton : MonoBehaviour
{
    public UnityEvent Click;
    private void OnMouseDown()
    {
        if(PasscodeTaskManager.Instance.IsRunning)
            Click?.Invoke();
    }
}
