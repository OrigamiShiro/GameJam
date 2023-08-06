using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _fireRate;

    private float _shootTimer;

    void Start()
    {
        _shootTimer = 0;
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && (_shootTimer <= 0))
        {
            Shoot();
            _shootTimer = _fireRate;
        }
        else
            _shootTimer -= Time.deltaTime;
    }

    private void Shoot() 
    {
        Instantiate(_bulletPrefab, transform.position, transform.rotation);
    }
}
