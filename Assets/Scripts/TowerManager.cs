using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public GameObject[] towerPrefabs; 
    private GameObject selectedTower; 

    public void SelectTower(int index)
    {
        if (index >= 0 && index < towerPrefabs.Length)
        {
            selectedTower = towerPrefabs[index];
            Debug.Log("Kule seçildi: " + selectedTower.name);
        }
    }

    public void PlaceTower(Vector3 position)
    {
        if (selectedTower != null)
        {
            Instantiate(selectedTower, position, Quaternion.identity);
            selectedTower = null; // if placed turn null
            Debug.Log("Kule yerleştirildi.");
        }
    }

    public bool HasSelectedTower()
    {
        return selectedTower != null;
    }
}
