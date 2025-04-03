using UnityEngine;
using UnityEngine.InputSystem;

public class GameplayTester : MonoBehaviour
{
    [SerializeField] CameraController cam1;
    [SerializeField] InputActionReference cameraDestroy;
    [SerializeField] InputActionAsset g;

    private void Start()
    {

#if !UNITY_EDITOR
        Destroy(gameObject);
        return;
#endif

        g.Enable();
        cameraDestroy.action.performed += Action_performed;
    }

    private void OnDestroy()
    {
        cameraDestroy.action.performed -= Action_performed;
    }

    private void Action_performed(InputAction.CallbackContext obj)
    {
        cam1.DestroyObject();
    }
}
