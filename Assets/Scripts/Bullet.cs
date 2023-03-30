using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public bool isPlayerBullet;
    public Vector3 direction;
    public float damage = 10f;

    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;

    private bool destroyed = false;

    private void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI);
    }

    public void FixedUpdate()
    {
        if (destroyed) return;
        // rb.velocity = Vector2.zero;
        rb.MovePosition(transform.position + direction.normalized * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isPlayerBullet && collision.collider.CompareTag("Enemy"))
        {
            collision.collider.gameObject.GetComponent<Enemy>().Hit(damage);
            Explode();
            return;
        }
        if (!isPlayerBullet && collision.collider.CompareTag("Player"))
        {
            collision.collider.gameObject.GetComponent<PlayerHealth>().Hit();
            Explode();
            return;
        }
        if (collision.collider.CompareTag("Ground"))
        {
            Explode();
        }
    }

    private void Explode()
    {
        destroyed = true;
        GetComponent<CircleCollider2D>().enabled = false;
        animator.Play("explosion");
        Destroy(gameObject, .5f);
    }

}
