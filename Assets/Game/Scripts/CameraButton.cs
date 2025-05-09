using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraButton : MonoBehaviour
{
    [SerializeField] MeshRenderer lightRenderer;
    [SerializeField] Collider buttonCollider;
    [SerializeField] Transform buttonTransform;
    Material material;

    public Action Pressed;

    private void Awake()
    {
        material = new(lightRenderer.material);
        lightRenderer.material = material;
    }

    public void Press()
    {
        buttonCollider.enabled = false;
        buttonTransform.localPosition = new(0, -0.05f, 0);
        material.color = Color.red;
        Pressed?.Invoke();
    }

    public void ResetNutton()
    {
        buttonCollider.enabled = true;
        buttonTransform.localPosition = new(0, 0, 0);
        material.color = new Color32(82, 0, 0, 255);
    }
}
