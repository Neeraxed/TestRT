using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Transform _additionalCamera;

    private Transform _clock;
    private Transform _passcode;
    private Transform _plates;

    private void Start()
    {
        _clock = ClockTaskManager.Instance.CameraPosition;
        _passcode = PasscodeTaskManager.Instance.CameraPosition;
        _plates = ClockTaskManager.Instance.CameraPosition;
    }

    private void MoveCameraTo(Transform transform)
    {
        while ((_playerTransform.position - transform.position).magnitude > (Vector3.one / 2).magnitude)
        {
            //_playerTransform.position = Vector3.MoveTowards(_playerTransform.position, transform.position, 5f);
            //_additionalCamera.position = Vector3.MoveTowards(_additionalCamera.position, transform.position, 5f);
            //_additionalCamera.rotation = Quaternion.RotateTowards(_additionalCamera.rotation, transform.rotation, 5f);

            _playerTransform.position = transform.position;
            _additionalCamera.position = transform.position;
            _additionalCamera.rotation = transform.rotation;
            _additionalCamera.gameObject.SetActive(true);
            _playerTransform.gameObject.SetActive(false);
        }
    }

    private void UnLockCamera() { _playerTransform.gameObject.SetActive(true); _additionalCamera.gameObject.SetActive(false); }

    private void OnEnable()
    {
        ClockTaskManager.Started += () => MoveCameraTo(_clock);
        ClockTaskManager.Completed += UnLockCamera;

        PasscodeTaskManager.Started += () => MoveCameraTo(_passcode);
        PasscodeTaskManager.Completed += UnLockCamera;

        PlatesTaskManager.Started += () => MoveCameraTo(_plates);
        PlatesTaskManager.Completed += UnLockCamera;
    }
    private void OnDisable()
    {
        ClockTaskManager.Started -= () => MoveCameraTo(ClockTaskManager.Instance.CameraPosition);
        ClockTaskManager.Completed -= UnLockCamera;

        PasscodeTaskManager.Started -= () => MoveCameraTo(_passcode);
        PasscodeTaskManager.Completed -= UnLockCamera;

        PlatesTaskManager.Started -= () => MoveCameraTo(_plates);
        PlatesTaskManager.Completed -= UnLockCamera;
    }
}
