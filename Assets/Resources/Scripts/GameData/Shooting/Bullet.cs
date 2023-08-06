using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _lifeTime = 3f;

    private Rigidbody2D _bulletBody;

    void Start()
    {
        
        Destroy(gameObject, _lifeTime);
    }

    void FixedUpdate()
    {
        gameObject.transform.Translate(0, _speed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
