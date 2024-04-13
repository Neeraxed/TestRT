using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform PlayerTransform;
    [SerializeField] private Transform AdditionalCamera;

    private void MoveCameraTo(Transform position)
    {       
        PlayerTransform.position = Vector3.MoveTowards(PlayerTransform.position, ClockTaskManager.Instance.CameraPosition.position, 5f);
        AdditionalCamera.position = Vector3.MoveTowards(AdditionalCamera.position, ClockTaskManager.Instance.CameraPosition.position, 5f);
        AdditionalCamera.gameObject.SetActive(true);
        PlayerTransform.gameObject.SetActive(false);
    }

    private void UnLockCamera() { PlayerTransform.gameObject.SetActive(true); AdditionalCamera.gameObject.SetActive(false); }

    private void OnEnable()
    {
        ClockTaskManager.Started += () => MoveCameraTo(ClockTaskManager.Instance.CameraPosition);
        ClockTaskManager.Completed += UnLockCamera;
    }
    private void OnDisable()
    {
        ClockTaskManager.Started -= () => MoveCameraTo(ClockTaskManager.Instance.CameraPosition);
        ClockTaskManager.Completed -= UnLockCamera;
    }
}
