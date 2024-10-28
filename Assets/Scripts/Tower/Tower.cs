using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    [SerializeField] private float fireRate = 1f; 

    private bool isShooting = false;
    private Transform currentTarget;
    public int price = 20; 


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
