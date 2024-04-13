using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private TaskType _task;
    public void Interact()
    {
        switch (_task)
        {
            case(TaskType.Clock):
                ClockTaskManager.Started?.Invoke();
                break;
            case (TaskType.Passcode):
                PasscodeTaskManager.Started?.Invoke();
                break;
            case (TaskType.Plates):
                PlatesTaskManager.Started?.Invoke();
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
