using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSceneTrigger : MonoBehaviour
{
    [SerializeField] private GameObject go;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        
        if (collision.gameObject.TryGetComponent<PlayerShoter>(out PlayerShoter ps))
        {
            go.SetActive(true);
            Destroy(gameObject);
        }
    }
}
