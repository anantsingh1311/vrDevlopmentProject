using UnityEngine;

public class GameMenuManager : MonoBehaviour
{
    [SerializeField] GameObject objectiveHolder;
    [SerializeField] GameObject inventoryHolder;

    [SerializeField] GameObject[] inventoryItems;

    public void OpenMenu()
    {
        gameObject.SetActive(true);
        ObjectiveClicked();
        UpdateInventoryItems();
    }

    public void CloseMenu()
    {
        gameObject.SetActive(false);
    }

    void UpdateInventoryItems()
    {
        foreach (var itemUI in inventoryItems)
        {
            itemUI.SetActive(false);
        }

        foreach(var item in GameStateManager.Instance.items)
        {
            inventoryItems[item.Index].SetActive(true);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ObjectiveClicked()
    {
        objectiveHolder.SetActive(true);
        inventoryHolder.SetActive(false);
    }

    public void InventoryClicked()
    {
        objectiveHolder.SetActive(false);
        inventoryHolder.SetActive(true);
    }
}
