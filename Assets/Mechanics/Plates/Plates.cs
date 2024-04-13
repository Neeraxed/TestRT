using UnityEngine;

public class Plates : MonoBehaviour
{
    [SerializeField] private Transform _outerPlate;
    [SerializeField] private Transform _midPlate;
    [SerializeField] private Transform _innerPlate;

    public Transform OuterPlate { get => _outerPlate; set => _outerPlate = value; }
    public Transform MidPlate { get => _midPlate; set => _midPlate = value; }
    public Transform InnerPlate { get => _innerPlate; set => _innerPlate = value; }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && PlatesTaskManager.Instance.IsRunning)
            PlatesTaskManager.OnRefreshed?.Invoke();
    }

    private void CheckPosition()
    {
        if (Mathf.Round(_outerPlate.rotation.eulerAngles.y) % 360 == 0 && Mathf.Round(_midPlate.rotation.eulerAngles.y) % 360 == 0 &&
             Mathf.Round(_innerPlate.rotation.eulerAngles.y) % 360 == 0)
            PlatesTaskManager.Completed?.Invoke();
    }

    private void OnEnable()
    {
        Plate.Clicked += CheckPosition;
    }
    private void OnDisable()
    {
        Plate.Clicked -= CheckPosition;
    }
}
