using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    private TowerManager towerManager;
    private bool isOccupied = false; // tower placed check

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
            Debug.Log("tower placed");
        }
        else if (isOccupied)
        {
            Debug.Log("a tower aldready placed");
        }
        else
        {
            Debug.Log("select a tower");
        }
    }

}
