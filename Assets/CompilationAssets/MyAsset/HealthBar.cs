using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerLive PlayerLive;
    [SerializeField] private Image imageHealth;
    [SerializeField] private Image imageHappy;

    private void Update()
    {
        if ((imageHealth || imageHappy) && PlayerLive)
        {
            if (imageHappy) imageHappy.fillAmount = PlayerLive._happy / PlayerLive._maxHappy;
            if (imageHealth) imageHealth.fillAmount = PlayerLive._health / PlayerLive._maxHealth;
        }
    }

}
