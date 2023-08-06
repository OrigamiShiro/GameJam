using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
    public class Pistol : MonoBehaviour, IGun
    {
        [SerializeField]
        private BaseGun _pistolData;
        
        public void Attack()
        {
        }
    }
}