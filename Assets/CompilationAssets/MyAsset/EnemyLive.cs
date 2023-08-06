using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLive : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _damage;
    [SerializeField] private float _giveHappy;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerBulletLive>(out PlayerBulletLive pbl))
        {
            _health -= pbl.damage;
            Destroy(collision.gameObject);
            if (_health <= 0)
            {
                Death();
            }
        }
        else if(collision.gameObject.TryGetComponent<PlayerLive>(out PlayerLive pl))
        {
            pl._health -= _damage;
            pl._happy += _giveHappy;
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
