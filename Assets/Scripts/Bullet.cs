using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 10f;
    public float height = 5f; // parabol
    private float timeAlive; 
    private Vector2 startPos;
    public int damage = 5;
    [SerializeField] private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Seek(Transform _target)
    {
        target = _target;
        startPos = transform.position; 
        timeAlive = 0f; 
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        timeAlive += Time.deltaTime; 

        Vector2 targetPos = target.position;
        float distanceCovered = timeAlive * speed;
        float totalDistance = Vector2.Distance(startPos, targetPos);

        float heightOffset = height * Mathf.Sin((distanceCovered / totalDistance) * Mathf.PI);

        Vector2 newPosition = Vector2.Lerp(startPos, targetPos, distanceCovered / totalDistance);
        newPosition.y += heightOffset;
        transform.position = newPosition;

        if (distanceCovered >= totalDistance)
        {
            HitTarget();
        }
    }

    void HitTarget()
    {
        Destroy(gameObject); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.CompareTag("Enemy"))
            {
                EnemyHealth enemy = collision.GetComponent<EnemyHealth>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }
            }
            Destroy(gameObject, 2f);
    }
    }
