using DG.Tweening;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Transform _additionalCamera;
    [SerializeField] private float _movementDuration;

    private Transform _clock;
    private Transform _passcode;
    private Transform _plates;

    private void Start()
    {
        _clock = ClockTaskManager.Instance.CameraPosition;
        _passcode = PasscodeTaskManager.Instance.CameraPosition;
        _plates = PlatesTaskManager.Instance.CameraPosition;
    }

    private void MoveCameraTo(Transform tr)
    {
        if(_playerTransform.position != tr.position)
        {
            _additionalCamera.DOMove(tr.position, _movementDuration);
            _additionalCamera.DOMove(tr.position, _movementDuration);
            _additionalCamera.DORotate(tr.rotation.eulerAngles, _movementDuration);

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
        ClockTaskManager.Started -= () => MoveCameraTo(_clock);
        ClockTaskManager.Completed -= UnLockCamera;

        PasscodeTaskManager.Started -= () => MoveCameraTo(_passcode);
        PasscodeTaskManager.Completed -= UnLockCamera;

        PlatesTaskManager.Started -= () => MoveCameraTo(_plates);
        PlatesTaskManager.Completed -= UnLockCamera;
    }
}
