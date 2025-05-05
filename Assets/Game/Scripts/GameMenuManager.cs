using UnityEngine;

public class GameMenuManager : MonoBehaviour
{
    [SerializeField] GameObject objectiveHolder;
    [SerializeField] GameObject inventoryHolder;

    public void OpenMenu()
    {
        ObjectiveClicked();
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
