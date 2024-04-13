using System;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public static Action Clicked;
    private void OnMouseDown()
    {
        if (PlatesTaskManager.Instance.IsRunning)
        {
            transform.Rotate(Vector3.up, 10);
            Clicked?.Invoke();
        }
    }
}
