using UnityEngine;

public class PlayerShoter : MonoBehaviour
{
    [SerializeField] private KeyCode _shotKeyCode;
    private Transform _playerTransform;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _transformShotPoint;
    [SerializeField] private float _shotForse;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private int _damage;
    [SerializeField] private float _cullDownMax;
    private float _cullDown;


    [SerializeField]  private PlayerGun _playerGun;

    private void Start()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
        _audioSource.volume = PlayerPrefs.GetFloat("SoundVolume");
        _playerTransform = GetComponent<Transform>();

        if (_shotKeyCode == KeyCode.None)
            _shotKeyCode = (KeyCode)PlayerPrefs.GetInt("ButtonShot") ==
                KeyCode.None ? KeyCode.X : (KeyCode)PlayerPrefs.GetInt("ButtonShot");

        UpdateWeapon();
    }

    private void Update()
    {
        _cullDown -= Time.deltaTime;
        if (Input.GetKey(_shotKeyCode))
        {
            if (_cullDown <= 0)
            {
                Shot();
            }
        }
    }

    public void UpdateWeapon()
    {
        _playerGun = GetComponentInChildren<PlayerGun>();
        if (_playerGun)
        {
            _bullet = _playerGun._bullet;
            _shotForse = _playerGun._forseShot;
            _damage = _playerGun._damage;
            _transformShotPoint = _playerGun._transformShotPoint;
            _cullDownMax = _playerGun._cullDown;
        }
    }

    private void Shot()
    {
        _cullDown = _cullDownMax;
        bool lookLeft = _playerTransform.localScale.x > 0;
        Vector3 shotPoint = _transformShotPoint.transform.position;
        GameObject bulet = Instantiate(_bullet, shotPoint, Quaternion.identity);
        bulet.GetComponent<Rigidbody2D>().AddForce(new Vector2(_shotForse * (lookLeft ? -1 : 1), 0));
        if (bulet.TryGetComponent<PlayerBulletLive>(out PlayerBulletLive pl))
        {
            pl.damage = _damage;
        }


        //_audioSource.PlayOneShot(_audioClip);
    }
}