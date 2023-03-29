using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = .05f;
    public bool isPlayerBullet;
    public Vector3 direction;
    public float damage = 10f;

    [SerializeField] private Rigidbody2D rb;

    public void FixedUpdate()
    {
        rb.MovePosition(transform.position + direction * speed);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (isPlayerBullet && collider.CompareTag("Enemy"))
        {
            collider.gameObject.GetComponent<Enemy>().Hit(damage);
            Destroy(gameObject);
            return;
        }
        if (!isPlayerBullet && collider.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<PlayerHealth>().Hit(damage, transform.position);
            Destroy(gameObject);
            return;
        }
        if (collider.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
