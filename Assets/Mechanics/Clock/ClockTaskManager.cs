using UnityEngine;

public class ClockTaskManager : TasksManager
{
    [SerializeField] private Transform _cameraPosition;
    [SerializeField] private Clock _clock;
    private bool _isRunning;
    private bool _isComplete;
    System.Random r = new System.Random();

    public override bool IsRunning { get => _isRunning; protected set => _isRunning = value; }
    public override bool IsComplete { get => _isComplete; protected set => _isComplete = value; }
    public override Transform CameraPosition { get => _cameraPosition; protected set => _cameraPosition = value; }

    private void OnEnable()
    {
        Clock.Completed += CompleteTask;
    }

    private void OnDisable()
    {
        Clock.Completed -= CompleteTask;
    }

    protected override void StartTask()
    {
        base.StartTask();
    }

    protected override void CompleteTask()
    {
        base.CompleteTask();
        _isComplete = true;
        Debug.Log("First task completed");
    }

    protected override void Refresh()
    {
        _clock.MinuteDegrees = r.Next(0, 11);
        _clock.HourDegrees= r.Next(0, 359);
    }    
}
