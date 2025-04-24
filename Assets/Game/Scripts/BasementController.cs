using NavKeypad;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementController : MonoBehaviour
{
    [SerializeField] Transform door1, door2;

    [SerializeField] Keypad keypad;
    [SerializeField] GameObject[] floors;

    private void Start()
    {
        keypad.OnAccessGranted.AddListener(Unlock);

        if (GameStateManager.Instance.BasementUnlocked)
            keypad.OnAccessGranted?.Invoke();
    }

    void Unlock()
    {
        GameStateManager.Instance.BasementUnlocked = true;
        door1.localEulerAngles = new(0, 0, 75);
        door2.localEulerAngles = new(-90, 0, 45);

        foreach (var floor in floors)
            floor.SetActive(true);
    }
}
