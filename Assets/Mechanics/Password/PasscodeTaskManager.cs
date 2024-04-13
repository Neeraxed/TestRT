using System;
using UnityEngine;

public class PasscodeTaskManager : TaskManager
{
    public static Action Started;
    public static Action Completed;
    public static Action AskForRefresh;
    public static Action OnRefreshed;

    [SerializeField] private Transform _cameraPosition;
    [SerializeField] private Passcode _passcode;

    private System.Random r = new System.Random();
    private bool _isRunning;
    private bool _isComplete;

    public static PasscodeTaskManager Instance { get; private set; }
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
        var a = r.Next(1000, 9999);
        _passcode.Code = a.ToString();
        OnRefreshed?.Invoke();
    }
}
 