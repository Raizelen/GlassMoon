using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float health;


    private void Start()
    {
        health = 100f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            health -= collision.gameObject.GetComponent<Enemy>().damage;
            InGameUIManager.instance.UpdateHealth(health);
            InGameUIManager.instance.PlayDanger();
            if (health <= 0)
            {
                Die();
            }
        }
    }

    public void Hit(float damage)
    {
        health -= damage;
        InGameUIManager.instance.UpdateHealth(health);
        InGameUIManager.instance.PlayDanger();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("DEATH");
    }
}
