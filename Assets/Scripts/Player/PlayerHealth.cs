using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            var damage = collision.gameObject.GetComponent<Enemy>().damage;
            Hit();
        }
    }

    public void Hit()
    {
        Die();
    }

    private void Die()
    {
        AudioManager.instance.PlayOneShot(4);
        GameManager.instance.OnPlayerDeath();
    }
}
