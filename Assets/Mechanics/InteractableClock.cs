using UnityEngine;

public class InteractableClock : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log($"{this.name} was interacted");
        ClockTaskManager.Started?.Invoke();
    }
}
