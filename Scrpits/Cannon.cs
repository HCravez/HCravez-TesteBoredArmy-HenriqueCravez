using UnityEngine;
using System.Collections;
using UnityEngine.Playables;
using UnityEngine.UI;

public class Cannon : MonoBehaviour
{
    public GameObject bullet;
    public GameObject explosaoPequena;
    public Transform spawnPoint;

    public float myTime = 1;
    public float fireDelta = 0.5f;
    private float nextFire =  0.5f;
    
    private GameObject explosao;

    private void Start()
    {
        explosao = null;
        myTime = 1;
    }
    void Update ()
    {
        
        myTime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.P) && myTime > nextFire)
        {
            nextFire = myTime + fireDelta;
            
            Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
            
            explosao = Instantiate(explosaoPequena, spawnPoint.position, spawnPoint.rotation);

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