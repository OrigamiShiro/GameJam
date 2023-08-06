using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeGunTrigger : MonoBehaviour
{
    [SerializeField] private GameObject gun;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerShoter>(out PlayerShoter ps))
        {
            Destroy(collision.gameObject.GetComponentInChildren<PlayerGun>().gameObject);
            Instantiate(gun, collision.gameObject.transform);
            ps.UpdateWeapon();
            Destroy(gameObject);
        }
    }
}
