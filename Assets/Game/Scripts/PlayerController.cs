using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject rayInteractor;
    [SerializeField] GameObject teleportInteractor;
    [SerializeField] GameObject grabInteractor;
    [SerializeField] GameObject menuObject;

    [SerializeField] InputActionReference modeButton;

    int currentMode = -1;

    private void Start()
    {
        ChangeMode();
        //modeButton.action.performed += Action_performed;
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
                menuObject.SetActive(false);
                break;
            case 1:
                teleportInteractor.SetActive(false);
                grabInteractor.SetActive(false);
                rayInteractor.SetActive(true);
                menuObject.SetActive(true);
                break;
        }
    }

    private void OnDestroy()
    {
        modeButton.action.performed -= Action_performed;
    }
}
