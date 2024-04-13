using TMPro;
using UnityEngine;

public class VisualSetter : MonoBehaviour
{
    [SerializeField] private TextMeshPro _ClockTMPRO;
    [SerializeField] private TextMeshPro _PasscodeTMPRO;
    [SerializeField] private Clock _clock;
    [SerializeField] private Passcode _passcode;

    private void OnEnable()
    {
        ClockTaskManager.OnRefreshed += () => SetValue(_ClockTMPRO, _clock.ConvertTimeToString());
        PasscodeTaskManager.OnRefreshed += () => SetValue(_PasscodeTMPRO, _passcode.Code);
    }
    private void OnDisable()
    {
        ClockTaskManager.OnRefreshed -= () => SetValue(_ClockTMPRO, _clock.ConvertTimeToString());
        PasscodeTaskManager.OnRefreshed -= () => SetValue(_PasscodeTMPRO,_passcode.Code);

    }

    private void Start()
    {
        SetValue(_PasscodeTMPRO,_passcode.Code);
    }

    private void SetValue(TextMeshPro tmpro, string str)
    {
        tmpro.text = str;
    }

}
