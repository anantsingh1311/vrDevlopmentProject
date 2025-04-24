using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorItem : MonoBehaviour, IHighlightable
{
    [SerializeField] MeshRenderer itemRenderer;
    Material material;

    [SerializeField] Collider itemCollider;
    [SerializeField] string sceneName;

    private void Awake()
    {
        material = new Material(itemRenderer.material);
        itemRenderer.material = material;
    }

    public void DeHighlight()
    {
        material.color = Color.white;
    }

    public void Highlight()
    {
        material.color = Color.cyan;
    }

    public void Loaded()
    {
        GameStateManager.Instance.EnteredBar = true;
        SceneManager.LoadScene(sceneName);
    }
}
