using System;
using UnityEngine;

public class Clock : MonoBehaviour, IInteractable
{
    [SerializeField, Range(0,11)] private float _minuteDegrees = 30;
    [SerializeField, Range(0, 359)] private float _hourDegrees = 212.5f;

    public float MinuteDegrees {  get { return _minuteDegrees; } set {  if((value >= 0) && (value < 12)) _minuteDegrees = value; } }
    public float HourDegrees {  get { return _hourDegrees; } set {  if((value >= 0) && (value < 360)) _hourDegrees = value; } }

    [SerializeField] private Transform _minuteHand;
    [SerializeField] private Transform _hourHand;

    public static Action Started;
    public static Action Completed;
    public static Action Refreshed;

    public void Interact()
    {
        Debug.Log($"{this.name} was interacted");
        Started?.Invoke();
    }

    private void OnMouseDown()
    {
        _minuteHand.Rotate(Vector3.back, 30);
        _hourHand.Rotate(Vector3.back, 2.5f);

        if((Mathf.Round(_minuteHand.rotation.eulerAngles.z * 2) /2) == _minuteDegrees &&
            (Mathf.Round(_hourHand.rotation.eulerAngles.z * 2) / 2) == _hourDegrees)
            Completed?.Invoke();

        if(Input.GetKeyDown(KeyCode.R))
            Refreshed?.Invoke();
    }
}
