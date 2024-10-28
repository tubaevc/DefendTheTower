using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [SerializeField] private List<TowerData> towerDataList; 
    private GameObject selectedTowerPrefab;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    public void SelectTower(int towerIndex)
    {
        if (towerIndex >= 0 && towerIndex < towerDataList.Count)
        {
            selectedTowerPrefab = towerDataList[towerIndex].prefab;
            Debug.Log("Selected Tower: " + (selectedTowerPrefab != null ? selectedTowerPrefab.name : "None"));
        }
        else
        {
            selectedTowerPrefab = null;
            Debug.Log("Invalid tower index");
        }
    }

    public bool HasSelectedTower()
    {
        return selectedTowerPrefab != null;
    }

    public void PlaceTower(Vector3 position)
    {
        if (selectedTowerPrefab != null)
        {
            int towerPrice = selectedTowerPrefab.GetComponent<Tower>().price;

            if (gameManager.SpendBudget(towerPrice))
            {
                Instantiate(selectedTowerPrefab, position, Quaternion.identity);
                Debug.Log("Tower placed and budget deducted");
                selectedTowerPrefab = null;
            }
            else
            {
                Debug.Log("Not enough budget to place this tower.");
            }
        }
    }
}
