using UnityEngine;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{
    [SerializeField] private float _interactorRange;
    [SerializeField] private KeyCode _interactionKey = KeyCode.E;
    [SerializeField] private Image _detector;
    [SerializeField] private LayerMask _interactableLayerMask;

    public void ActivateDetector(bool value)
    {
        _detector.gameObject.SetActive(value);
    }

    private void Update()
    {
        RaycastHit hit;
        if ((Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, _interactorRange, _interactableLayerMask)))
        {
            if (hit.collider.TryGetComponent(out Interactable interactable))
            {
                ActivateDetector(true);
                if (Input.GetKeyDown(_interactionKey))
                { 
                    interactable.Interact();    
                }
            }
        }
        else
            ActivateDetector(false);
    }

    private void OnDisable()
    {
        ActivateDetector(false);
    }
}
