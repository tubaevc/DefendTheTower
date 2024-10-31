using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerData", menuName = "TowerDefense/Tower Data")]
public class TowerData : ScriptableObject
{
    public GameObject prefab;
    public int price;

    [Header("Upgrade Settings")]
    public int upgradePrice;
    public GameObject upgradedPrefab; 
}