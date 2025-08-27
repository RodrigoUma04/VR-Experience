using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionTest : MonoBehaviour
{
    [SerializeField] private InputActionReference activate;

    private void Start()
    {
        activate.action.performed += OnActivate;
    }

    private void OnActivate(InputAction.CallbackContext context)
    {
        Debug.Log("Right Hand Activated!");
    }
}
