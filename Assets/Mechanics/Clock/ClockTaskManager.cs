using System;
using UnityEngine;

public class ClockTaskManager : TaskManager
{
    public static Action Started;
    public static Action Completed;
    public static Action AskForRefresh;
    public static Action OnRefreshed;

    [SerializeField] private Transform _cameraPosition;
    [SerializeField] private Clock _clock;
    
    private bool _isRunning;
    private bool _isComplete;
    private System.Random r = new System.Random();

    public static ClockTaskManager Instance { get; private set; }
    public override bool IsRunning { get => _isRunning; protected set => _isRunning = value; }
    public override bool IsComplete { get => _isComplete; protected set => _isComplete = value; }
    public override Transform CameraPosition { get => _cameraPosition; protected set => _cameraPosition = value; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance = this)
            Destroy(gameObject);
    }

    private void OnEnable()
    {
        Started += StartTask;
        Completed += CompleteTask;
        AskForRefresh += Refresh;
    }

    private void OnDisable()
    {
        Started -= StartTask;
        Completed -= CompleteTask;
        AskForRefresh -= Refresh;
    }

    protected override void StartTask()
    {
        base.StartTask();
        _isRunning = true;
    }

    protected override void CompleteTask()
    {
        base.CompleteTask();
        _isRunning = false;
        _isComplete = true;
    }

    protected override void Refresh()
    {
        _clock.MinuteDegrees = (Mathf.Round(r.Next(0, 360) / 30) * 30);
        _clock.HourDegrees= (Mathf.Round(r.Next(180, 360) / 5) * 5);
        OnRefreshed?.Invoke();
    }    
}
