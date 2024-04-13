using TMPro;
using UnityEngine;

public class VisualSetter : MonoBehaviour
{
    [SerializeField] private TextMeshPro _ClockTMPRO;
    [SerializeField] private TextMeshPro _PasscodeTMPRO;
    [SerializeField] private Passcode _passcode;

    private void OnEnable()
    {
        PasscodeTaskManager.OnRefreshed += () => SetValue(_PasscodeTMPRO, _passcode.Code);
    }
    private void OnDisable()
    {
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
