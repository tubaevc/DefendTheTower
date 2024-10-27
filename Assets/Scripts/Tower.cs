using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject bulletPrefab;   
    public Transform firePoint;       

    private bool hasShot = false;    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !hasShot)
        {
            Debug.Log("enemy entered the towers range: " + collision.gameObject.name);
            Shoot(collision.transform); 
            hasShot = true;              
        }
    }

    void Shoot(Transform target)
    {
        //Debug.Log("shoot function"); 
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Debug.Log("bullet instantiated"); 
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.Seek(target);
            Debug.Log("Bullet seeking the target!"); 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            hasShot = false; 
        }
    }
}
