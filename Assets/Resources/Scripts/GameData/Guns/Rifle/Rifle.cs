using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
    public class Rifle : MonoBehaviour, IGun
    {
        [SerializeField] private BaseGun _rifleData;
        
        public void Attack()
        {
            throw new System.NotImplementedException();
        }
    }
}
