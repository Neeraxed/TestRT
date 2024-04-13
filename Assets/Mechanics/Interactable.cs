using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private TaskType _task;
    public void Interact()
    {
        Debug.Log($"{this.name} was interacted");

        switch (_task)
        {
            case(TaskType.Clock):
                ClockTaskManager.Started?.Invoke();
                break;
            case (TaskType.Passcode):
                PasscodeTaskManager.Started?.Invoke();
                break;
            case (TaskType.Plates):
                PasscodeTaskManager.Started?.Invoke();
                break;
        }
        
    }
}

public enum TaskType
{
    Clock,
    Passcode,
    Plates
}
