using UnityEngine;

public class PlayerBulletLive : MonoBehaviour
{
    [SerializeField] private float _timeToDestroy;
    [SerializeField] private GameObject _particleOnDestroy;
    [HideInInspector] public int damage;

    private void Start()
    {
        Invoke(nameof(DestroyThis), _timeToDestroy);
    }

    public void DestroyThis()
    {
        if (_particleOnDestroy)
            Instantiate(_particleOnDestroy, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            DestroyThis();
        
    }
}