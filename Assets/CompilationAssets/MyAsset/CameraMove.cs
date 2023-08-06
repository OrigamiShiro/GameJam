using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private float t;
    [SerializeField] private bool _canStart;

    [SerializeField] private Vector2 Maximum;
    [SerializeField] private Vector2 Minimum;

    private Vector3 posEnd, posSmooth;


    void LateUpdate()
    {
        if (Player != null && _canStart)
        {


            posEnd = new Vector3(Player.position.x, Player.position.y + 1, transform.position.z);

            posSmooth = Vector3.Lerp(transform.position, posEnd, t);

            if (posSmooth.x > Minimum.x && posSmooth.x < Maximum.x)
            {
                if (posSmooth.y > Minimum.y && posSmooth.y < Maximum.y)
                {
                    transform.position = posSmooth;
                }
                else
                {
                    if (posSmooth.y > Minimum.y)
                    {
                        transform.position = new Vector3(posSmooth.x, Maximum.y, transform.position.z);
                    }
                    else
                    {
                        transform.position = new Vector3(posSmooth.x, Minimum.y, transform.position.z);
                    }
                }
            }
            else
            {
                if (posSmooth.x > Minimum.x)
                {
                    if (posSmooth.y > Minimum.y && posSmooth.y < Maximum.y)
                    {
                        transform.position = new Vector3(Maximum.x, posSmooth.y, transform.position.z);
                    }
                    else
                    {
                        if (posSmooth.y > Minimum.y)
                        {
                            transform.position = new Vector3(Maximum.x, Maximum.y, transform.position.z);
                        }
                        else
                        {
                            transform.position = new Vector3(Maximum.x, Minimum.y, transform.position.z);
                        }
                    }
                }
                else
                {
                    if (posSmooth.y > Minimum.y && posSmooth.y < Maximum.y)
                    {
                        transform.position = new Vector3(Minimum.x, posSmooth.y, transform.position.z);
                    }
                    else
                    {
                        if (posSmooth.y > Minimum.y)
                        {
                            transform.position = new Vector3(Minimum.x, Maximum.y, transform.position.z);
                        }
                        else
                        {
                            transform.position = new Vector3(Minimum.x, Minimum.y, transform.position.z);
                        }
                    }
                }
            }

        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }   
    }
}
