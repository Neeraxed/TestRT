using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PassButton : MonoBehaviour
{
    public UnityEvent Click;

    private void OnMouseDown()
    {
        Debug.Log("AAA");
        if (PasscodeTaskManager.Instance.IsRunning)
            Click?.Invoke();
    }
}
