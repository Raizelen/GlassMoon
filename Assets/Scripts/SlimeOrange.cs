using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeOrange : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float startAngle = 30f;
    [SerializeField] float endAngle = 150f;
    [SerializeField] int numberOfBullets = 5;
    [SerializeField] float interval = 3f;

    public void Start()
    {
        StartCoroutine(SpawnBullets());
    }

    private IEnumerator SpawnBullets()
    {
        while (true)
        {
            for (float angle = startAngle; angle < endAngle; angle += (endAngle - startAngle) / numberOfBullets)
            {
                GameObject _bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity, transform);
                Bullet b = _bullet.GetComponent<Bullet>();
                b.direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
                b.isPlayerBullet = false;
                b.speed = 1.5f;
            }
            yield return new WaitForSeconds(interval);
        }
    }
}
