using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = .1f;
    public bool isPlayerBullet;
    public Vector2 direction;
    public float damage = 10f;

    public void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        // if (Vector2.Distance(transform.position, GameManager.instance.player.transform.position) > 100) Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isPlayerBullet && collision.collider.CompareTag("Enemy"))
        {
            collision.collider.gameObject.GetComponent<Enemy>().Hit(damage);
            Destroy(gameObject);
            return;
        }
        if (!isPlayerBullet && collision.collider.CompareTag("Player"))
        {
            collision.collider.gameObject.GetComponent<Player>().Hit(damage);
            Destroy(gameObject);
            return;
        }
    }
}
