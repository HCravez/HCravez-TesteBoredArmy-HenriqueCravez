using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCannonBall : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D Objeto2)
    {
        if (Objeto2.gameObject.name == "Player" )
        {
            Destroy(gameObject);
            PlayerPrefs.SetInt("vidaPlayer",PlayerPrefs.GetInt("vidaPlayer") - 20);
        }

        if (Objeto2.gameObject.tag == "ILHAS" || Objeto2.gameObject.name == "Chaser(Clone)" )
        {
            Destroy(gameObject);
        }
    }
}