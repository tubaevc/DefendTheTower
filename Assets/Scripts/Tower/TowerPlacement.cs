using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    private TowerManager towerManager;
    public bool isOccupied = false; // tower placed check
    public Tower currentTower;
    private Tower placedTower;
    private void Start()
    {
        towerManager = FindObjectOfType<TowerManager>();
    }


    private void OnMouseDown()
    {
        if (towerManager != null && towerManager.HasSelectedTower() && !isOccupied)
        {
            towerManager.PlaceTower(transform.position);
            isOccupied = true;
            Debug.Log("Tower placed");
        }
        else if (isOccupied)
        {
            Debug.Log("a tower aldready placed");
        }
        else
        {
            Debug.Log("Select a tower");
        }
    }
 
}
