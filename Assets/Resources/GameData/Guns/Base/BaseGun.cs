using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
    [CreateAssetMenu(fileName = "Gun", menuName = "Meta/Guns/CreateGun", order = 1)]
    public class BaseGun : ScriptableObject
    {
        [SerializeField] private float _damage;
        [SerializeField] private float _attackInterval;
        [SerializeField] private int _missilesCount;
        [SerializeField] private float _attackRange;
        
        public float Damage => _damage;
        public float AttackInterval => _attackInterval;
        public int MissilesCount => _missilesCount;
        public float AttackRange => _attackRange;
    }
}