using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLive : MonoBehaviour
{
    public float _maxHealth;
    public float _maxHappy;
    public float _health;
    public float _happy;

    private void FixedUpdate()
    {
        if (_health < 0)
        {
            Destroy(gameObject);
        }
    }
}
