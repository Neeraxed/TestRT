using UnityEngine;

public class Clock : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log($"{this.name} was interacted");
    }
}
