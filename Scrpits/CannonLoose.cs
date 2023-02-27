using UnityEngine;
using System.Collections;
using UnityEngine.Playables;
using UnityEngine.UI;

public class CannonLoose : MonoBehaviour
{
    public GameObject bullet;
    
    public Transform spawnPoint;
    public GameObject explosaoGrande;

    private GameObject explosao;

    public float myTime = 5;
    public float fireDelta = 3;
    private float nextFire = 2;
    public float deltinha = 0.1f;

    private void Start()
    {
        myTime = 5;
        explosao = null;
    }


    void Update()
    {
        
        myTime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.L) && myTime > nextFire) // o jogador so pode atirar de 2 em 2 segundos 
        {
            nextFire = myTime + fireDelta;

            Quaternion rotation1 = spawnPoint.rotation;
            Quaternion rotation2 = spawnPoint.rotation;
            Quaternion rotation3 = spawnPoint.rotation;

            rotation1.z += deltinha;
            rotation3.z -= deltinha;
            
            Instantiate(bullet, spawnPoint.position, rotation1);
            Instantiate(bullet, spawnPoint.position, rotation2);
            Instantiate(bullet, spawnPoint.position, rotation3);

            Vector3 v3 = spawnPoint.position;
            v3.z -= 0.1f;
            explosao = Instantiate(explosaoGrande, v3, spawnPoint.rotation);

            
            nextFire -= myTime;
            myTime = 0.0F;
        }

        if (explosao != null)
        {
            Vector3 v3 = spawnPoint.position;
            v3.z -= 0.1f;
            explosao.transform.position = v3;
        }
    }
}