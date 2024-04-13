using TMPro;
using UnityEngine;
public class Passcode : MonoBehaviour
{
    [SerializeField] private string _code = "4321";
    [SerializeField] private TextMeshPro _uiText = null;

    string _nr = null;
    int _nrIndex = 0;

    public string Code { get => _code; set { if (value.Length >= 4) { _code = value.Substring(0, 4); } else _code = "0000"; } }

    public void CodeFunction(string Numbers)
    {
        _nrIndex++;
        _nr = _nr + Numbers;
        _uiText.text = _nr;

    }
    public void Enter()
    {
        if (_nr == _code)
        {
            PasscodeTaskManager.Completed?.Invoke();
        }
    }
    public void Delete()
    {
        _nrIndex++;
        _nr = null;
        _uiText.text = _nr;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && PasscodeTaskManager.Instance.IsRunning)
            PasscodeTaskManager.AskForRefresh?.Invoke();
    }

}