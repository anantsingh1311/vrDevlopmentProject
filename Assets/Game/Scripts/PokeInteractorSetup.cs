using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PokeInteractorSetup : MonoBehaviour
{
    [SerializeField] Transform attachTransform;

    private void Start()
    {
        XRPokeInteractor pokeInteractor = FindObjectOfType<XRPokeInteractor>();
        pokeInteractor.attachTransform = attachTransform;
    }
}
