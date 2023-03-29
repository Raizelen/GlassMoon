using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private float health = 100;
    private float knockback = 50f;

    [SerializeField] Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            var damage = collision.gameObject.GetComponent<Enemy>().damage;
            Hit(damage, collision.transform.position);
        }
    }

    public void Hit(float damage, Vector3 origin)
    {
        health -= damage;
        rb.AddForce((transform.position - origin).normalized * knockback, ForceMode2D.Impulse);
        InGameUIManager.instance.UpdateHealth(health);
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GameManager.instance.OnPlayerDeath();
    }
}
