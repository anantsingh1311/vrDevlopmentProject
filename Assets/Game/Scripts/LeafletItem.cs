using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafletItem : MonoBehaviour, IHighlightable, IInventory
{
    [SerializeField] MeshRenderer itemRenderer;
    Material material;

    [SerializeField] Collider itemCollider;

    public event Action Added;

    private void Awake()
    {
        material = new Material(itemRenderer.material);
        itemRenderer.material = material;
    }

    private void Update()
    {
        material.color = (transform.position - Camera.main.transform.position).sqrMagnitude < 5 ? Color.cyan : Color.white;
    }

    public void DeHighlight()
    {
        material.SetFloat("_Outline", 0.0f);
    }

    public void Highlight()
    {
        material.SetFloat("_Outline", 0.4f);
    }
}
