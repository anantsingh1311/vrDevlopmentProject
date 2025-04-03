using UnityEngine;

public class StoneItem : MonoBehaviour, IHighlightable
{
    [SerializeField] Material material;

    public void DeHighlight()
    {
        material.SetFloat("_Outline", 0.0f);
    }

    public void Highlight()
    {
        material.SetFloat("_Outline", 0.4f);
    }
}
