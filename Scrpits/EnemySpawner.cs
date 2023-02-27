using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject shooter;
    public GameObject chaser;

    public Transform[] spawners = new Transform[10];
    
    
    private GameObject barco = null;
    
    private int numeroDeInimigosPorSpawn;
    private int spawnTime;
    // Start is called before the first frame update
    void Start()
    {
        numeroDeInimigosPorSpawn = PlayerPrefs.GetInt("numeroDeInimigosPorSpawn");
        spawnTime = PlayerPrefs.GetInt("tempoSpawn");
        InvokeRepeating ("Spawn", 0, spawnTime);
    }

    void Spawn ()
    {
        for (int i = 0; i < numeroDeInimigosPorSpawn; i++)
        {
            int x = Random.Range(0, 9);
            if (Random.value > 0.5)
            {
                barco = Instantiate(shooter, spawners[x].position, spawners[x].rotation);
            }
            else
            {
                barco = Instantiate(chaser, spawners[x].position, spawners[x].rotation);
            }
            barco.transform.rotation = Quaternion.Euler( 0, 0, Random.Range(0,360));
        }
    }
}
