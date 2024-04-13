using System;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField, Range(0, 360)] private float _minuteDegrees = 30;
    [SerializeField, Range(0, 360)] private float _hourDegrees = 212.5f;
    [SerializeField] private Transform _minuteHand;
    [SerializeField] private Transform _hourHand;

    private string _convertedTime;

    public float MinuteDegrees { get { return _minuteDegrees; } set { if ((value >= 0) && (value < 360)) _minuteDegrees = value; } }
    public float HourDegrees { get { return _hourDegrees; } set { if ((value >= 0) && (value < 360)) _hourDegrees = value; } }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && ClockTaskManager.Instance.IsRunning)
            ClockTaskManager.AskForRefresh?.Invoke();
    }

    private void OnMouseDown()
    {
        if (ClockTaskManager.Instance.IsRunning)
        {
            _minuteHand.Rotate(Vector3.back, 30);
            _hourHand.Rotate(Vector3.back, 2.5f);

            if ((Mathf.Round(_minuteHand.rotation.eulerAngles.z * 2) / 2) == _minuteDegrees &&
                (Mathf.Round(_hourHand.rotation.eulerAngles.z * 2) / 2) == _hourDegrees)
                ClockTaskManager.Completed?.Invoke();
        }        
    }

    public string ConvertTimeToString()
    {
        _convertedTime = "";
        var minutes = (int)_minuteHand.rotation.eulerAngles.z / 6;
        var hours = (int)_hourHand.rotation.eulerAngles.z / 30;
        _convertedTime = hours + ":" + minutes;
        return _convertedTime;
    }
}
