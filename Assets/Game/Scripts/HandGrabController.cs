using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandGrabController : MonoBehaviour
{
    [SerializeField]
    XRDirectInteractor grabInteractor;

    private void Start()
    {
        grabInteractor.hoverEntered.AddListener(OnHovered);
        grabInteractor.hoverExited.AddListener(OnHandHoverExit);
        grabInteractor.selectExited.AddListener(OnReleased);
    }

    private void OnReleased(SelectExitEventArgs item)
    {
        Component itemComponent = (item.interactableObject as Component);

        if (itemComponent.TryGetComponent(out IInventory inventory))
            GameStateManager.Instance.AddItem(inventory);
    }

    void OnHovered(HoverEnterEventArgs e)
    {
        Component itemComponent = (e.interactableObject as Component);

        if (itemComponent.TryGetComponent(out IHighlightable highlightItem))
            highlightItem.Highlight();
    }

    void OnHandHoverExit(HoverExitEventArgs e)
    {
        Component itemComponent = (e.interactableObject as Component);

        if (itemComponent.TryGetComponent(out IHighlightable highlightItem))
            highlightItem.DeHighlight();
    }
}
