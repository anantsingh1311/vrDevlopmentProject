using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject rayInteractor;
    [SerializeField] GameObject teleportInteractor;
    [SerializeField] GameObject grabInteractor;
    [SerializeField] GameMenuManager menuObject;

    [SerializeField] InputActionReference modeButton;
    [SerializeField] Transform camTransform;

    int currentMode = -1;

    private void Start()
    {
        ChangeMode();
        modeButton.action.performed += Action_performed;
        camTransform.position = new(0, camTransform.position.y, 0);
    }

    private void Action_performed(InputAction.CallbackContext obj)
    {
        ChangeMode();
    }

    void ChangeMode()
    {
        currentMode = (currentMode + 1) % 2;

        switch (currentMode)
        {
            case 0:
                teleportInteractor.SetActive(true);
                grabInteractor.SetActive(true);
                rayInteractor.SetActive(false);
                menuObject.CloseMenu();
                break;
            case 1:
                teleportInteractor.SetActive(false);
                grabInteractor.SetActive(false);
                rayInteractor.SetActive(true);
                menuObject.OpenMenu();
                break;
        }
    }

    private void OnDestroy()
    {
        modeButton.action.performed -= Action_performed;
    }
}
