
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance { get; private set; }

    bool[] objectives;

    List<IInventory> items = new();

    private void Awake()
    {
        Instance = this;
    }

    private void OnDestroy()
    {
        Instance = null;
    }


    public void AddItem(IInventory item)
    {
        (item as Component).gameObject.SetActive(false);
        items.Add(item);
    }

    public void SetObjectiveComplete(int objectiveId)
    {
        objectives[objectiveId] = true;
    }

    public int GetCurrentObjective()
    {
        int x = 0;

        while (objectives[x])
            x++;

        return x;
    }
}
