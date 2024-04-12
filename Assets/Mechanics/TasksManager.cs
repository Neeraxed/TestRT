using UnityEngine;

public abstract class TasksManager : MonoBehaviour
{
    public abstract bool IsRunning { get; protected set; }
    public abstract bool IsComplete { get; protected set; }

    public abstract Transform CameraPosition { get; protected set; }

    protected virtual void StartTask()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    protected virtual void CompleteTask() 
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    protected virtual void Refresh() { }
}
