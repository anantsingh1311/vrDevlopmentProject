using System;
using UnityEngine;

public class NewspaperItem : MonoBehaviour, IHighlightable, IInventory
{
    [SerializeField] MeshRenderer itemRenderer;
    Material material;

    [SerializeField] Collider itemCollider;
    [SerializeField] Canvas infoCanvas;

    public int Index { get; private set; } = 0;

    public event Action Added;

    private void Awake()
    {
        material = new Material(itemRenderer.material);
        itemRenderer.material = material;
        infoCanvas.worldCamera = Camera.main;
        infoCanvas.gameObject.SetActive(false);
    }

    public void DeHighlight()
    {
        material.SetFloat("_Outline", 0.0f);
    }

    public void Highlight()
    {
        material.SetFloat("_Outline", 0.4f);
    }

    public void OnGrabbed()
    {
        infoCanvas.gameObject.SetActive(true);
    }
}
