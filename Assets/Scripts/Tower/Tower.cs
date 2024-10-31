using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    [SerializeField] private float fireRate = 1f; 

    private bool isShooting = false;
    private Transform currentTarget;
    public int price = 20;

    public TowerData towerData; 
    public TowerManager towerManager;
    public bool isUpgraded = false;
    public Button upgradeButton;
    private GameManager gameManager;
    private void Start()
    {
        if (towerData == null)
        {
            Debug.LogError("TowerData is not assigned to the tower!");
        }
        upgradeButton = GetComponentInChildren<Button>();
        if (upgradeButton == null)
        {
            Debug.LogError("Upgrade button is not found in the prefab!");
            return;
        }
        if (upgradeButton != null)
        {
            upgradeButton.gameObject.SetActive(CanUpgrade());
            upgradeButton.onClick.AddListener(() =>TowerManager.UpgradeTower(this));
        }
        if (towerData == null)
        {
            Debug.LogError("TowerData is not assigned to the tower!");
        }
    }


    public void UpdateUpgradeButton()
    {
        if (upgradeButton != null)
        {
            upgradeButton.gameObject.SetActive(CanUpgrade() && gameManager.budget >= GetUpgradePrice());
        }
    }


    public bool CanUpgrade()
    {
        return !isUpgraded && towerData != null && towerData.upgradedPrefab != null;
    }

    public int GetUpgradePrice()
    {
        return towerData != null ? towerData.upgradePrice : 0;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !isShooting)
        {
            currentTarget = collision.transform;
            StartCoroutine(FireContinuously());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && collision.transform == currentTarget)
        {
            StopCoroutine(FireContinuously());
            currentTarget = null;
            isShooting = false; 
        }
    }

    private IEnumerator FireContinuously()
    {
        isShooting = true;
        while (currentTarget != null)
        {
            Shoot(currentTarget);
            yield return new WaitForSeconds(fireRate); 
        }
        isShooting = false;
    }

    private void Shoot(Transform target)
    {
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }
}

