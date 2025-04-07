using UnityEngine;

public class StoneItem : MonoBehaviour, IHighlightable
{
    [SerializeField] MeshRenderer itemRenderer;
    Material material;

    private void Awake()
    {
        material = new Material(itemRenderer.material);
        itemRenderer.material = material;
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
