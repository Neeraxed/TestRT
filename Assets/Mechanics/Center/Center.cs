using DG.Tweening;
using UnityEngine;

public class Center : MonoBehaviour
{
    [SerializeField] Transform _rotating;
    [SerializeField] Transform _moving;
    [SerializeField] Transform _scaling;

    [SerializeField] Transform _moveFinish;
    [SerializeField] float _duration;

    private void OnEnable()
    {
        ClockTaskManager.Completed += Rotate;
        PasscodeTaskManager.Completed += () => Move(_moveFinish);
        PlatesTaskManager.Completed += Scale;
    }

    private void OnDisable()
    {
        ClockTaskManager.Completed -= Rotate;
        PasscodeTaskManager.Completed -= () => Move(_moveFinish);
        PlatesTaskManager.Completed -= Scale;
    }
    private void Rotate()
    {
        _rotating.DORotate(new Vector3(360f, 360f, 0f), _duration)
            .SetLoops(-1, LoopType.Incremental)
            .SetRelative()
            .SetEase(Ease.Linear);
    }

    private void Move(Transform to)
    {
        _moving.DOMove(to.position, _duration).SetLoops(-1, LoopType.Yoyo);
    }

    private void Scale()
    {
        var originalScale = _scaling.localScale;
        var scaleTo = originalScale * 1.5f;
        _scaling.DOScale(scaleTo, _duration)
            .OnComplete(() =>
            {
                _scaling.DOScale(originalScale, _duration)
                .OnComplete(Scale);
            }); ;
    }
}
