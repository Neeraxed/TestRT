using System;
using UnityEngine;

public class PlatesTaskManager : TaskManager
{
    public static PlatesTaskManager Instance { get; private set; }

    [SerializeField] private Transform _cameraPosition;
    [SerializeField] private Plates _plates;

    private System.Random r = new System.Random();

    private bool _isRunning;
    private bool _isComplete;

    public override bool IsRunning { get => _isRunning; protected set => _isRunning = value; }
    public override bool IsComplete { get => _isComplete; protected set => _isComplete = value; }
    public override Transform CameraPosition { get => _cameraPosition; protected set => _cameraPosition = value; }

    public static Action Started;
    public static Action Completed;
    public static Action OnRefreshed;
    
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
        OnRefreshed += Refresh;
    }

    private void OnDisable()
    {
        Started -= StartTask;
        Completed -= CompleteTask;
        OnRefreshed -= Refresh;
    }

    protected override void StartTask()
    {
        base.StartTask();
        _isRunning = true;
        Debug.Log("Third task Started");
    }

    protected override void CompleteTask()
    {
        base.CompleteTask();
        _isRunning = false;
        _isComplete = true;
        Debug.Log("Third task completed");
    }

    protected override void Refresh()
    {
        _plates.OuterPlate.rotation = Quaternion.Euler(_plates.OuterPlate.rotation.x, (r.Next(0, 360) / 10) * 10, _plates.OuterPlate.rotation.z); 
        _plates.MidPlate.rotation = Quaternion.Euler(_plates.MidPlate.rotation.x, (r.Next(0, 360) / 10) * 10, _plates.MidPlate.rotation.z); 
        _plates.InnerPlate.rotation = Quaternion.Euler(_plates.InnerPlate.rotation.x, (r.Next(0, 360) / 10) * 10, _plates.InnerPlate.rotation.z); 
        Debug.Log("Third task Refreshed");
    }
}
 