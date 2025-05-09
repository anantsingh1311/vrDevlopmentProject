using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShutdownManager : MonoBehaviour
{
    [SerializeField] CameraButton[] buttons;
    [SerializeField] float maxTime;
    [SerializeField] TMPro.TMP_Text timeText;

    Coroutine timeIE;
    int pressCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach(var b in buttons)
        {
            b.Pressed += OnPressed;
        }
    }

    private void OnPressed()
    {
        timeIE ??= StartCoroutine(CountDownIE());

        pressCount++;

        if (pressCount == buttons.Length)
        {
            StopCoroutine(timeIE);
            Debug.Log("Finished");
            timeText.text = "You Finished the game.";
        }
    }

    IEnumerator CountDownIE()
    {
        float t = maxTime;

        while(t > 0)
        {
            int tInt = Mathf.FloorToInt(t * 100);
            timeText.text = $"{tInt / 100}.{tInt % 100}";
            t -= Time.deltaTime;
            yield return null;
        }

        foreach (var b in buttons)
            b.ResetNutton();

        timeText.text = "";
        timeIE = null;
    }
}
