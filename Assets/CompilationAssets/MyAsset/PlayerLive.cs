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
        else if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }
        
        
        
        if (_happy > _maxHappy)
        {
            _happy = _maxHappy; // win
        }
        else if (_happy <= 0)
        {
            _happy = 0;
            _health -= Time.deltaTime * 4;
        }
        else
        {
            _happy -= Time.deltaTime * 6;
        }


    }

    
}
