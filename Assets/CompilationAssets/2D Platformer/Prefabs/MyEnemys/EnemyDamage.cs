using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private float _damageHealth;
    [SerializeField] private float _addHappy;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.TryGetComponent<>)
        //{
        //
        //}
    }
}
