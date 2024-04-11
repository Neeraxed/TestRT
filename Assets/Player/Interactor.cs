using UnityEngine;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactorTransform;
    [SerializeField] private float _interactorRange;
    [SerializeField] private KeyCode _interactionKey = KeyCode.E;
    [SerializeField] private Image _detector;

    private void FixedUpdate()
    {
        DetectInteractions();
    }
    private void DetectInteractions()
    {
        Ray r = new Ray(_interactorTransform.position, _interactorTransform.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, _interactorRange))
        {
            ActivateDetector(true);
            if (Input.GetKeyDown(_interactionKey) && hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactable))
            {
                interactable.Interact();
            }
        }
        else
            ActivateDetector(false);
    }

    private void ActivateDetector(bool value)
    {
        _detector.gameObject.SetActive(value);
    }
}
