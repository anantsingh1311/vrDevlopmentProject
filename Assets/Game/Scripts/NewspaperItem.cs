using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewspaperItem : MonoBehaviour, IHighlightable
{
    [SerializeField] Material material;
    [SerializeField] Collider itemCollider;

    public void DeHighlight()
    {
        material.SetFloat("_Outline", 0.0f);
    }

    public void Highlight()
    {
        material.SetFloat("_Outline", 0.4f);
    }
}
