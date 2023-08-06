using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
    [CreateAssetMenu(fileName = "Unit", menuName = "Meta/Unit/CreateUnit", order = 2)]

    public class BaseUnit : ScriptableObject
    {
        [SerializeField] private float _maxHealth;
        [SerializeField] private float _moveSpeed;
        private IGun _gun;

        public float MaxHealth => _maxHealth;
        public float MoveSpeed => _moveSpeed;
        public IGun Gun => _gun;

        public void SwapGun(IGun newGun)
        {
            _gun = newGun;
        }
    }
}
