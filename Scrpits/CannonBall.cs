using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.position += transform.up * Time.deltaTime * 10f;
    }
    void OnCollisionEnter2D(Collision2D Objeto2)
    {
        if (Objeto2.gameObject.tag == "ILHAS" || Objeto2.gameObject.name == "Chaser(Clone)" || Objeto2.gameObject.name == "Shooter(Clone)" )
        {
            Destroy(gameObject);
        }
    }
}


