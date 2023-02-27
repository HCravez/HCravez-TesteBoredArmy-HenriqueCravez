using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosaoHandle : MonoBehaviour
{
    //animacoes
    public GameObject ExplosaoGrande;
    public GameObject ExplosaoPequena;
    public GameObject Fogo;

    //privates
    private GameObject explosao1;
    private GameObject explosao2;
    private GameObject explosao3;
    private GameObject fogo1;
    private GameObject fogo2;
    private Vector3 vector1;
    private Vector3 vector2;
    private Vector3 vector3;
    private Vector3 vector4;
    private Vector3 vector5;
    private Vector3 vector6;
    private float myTimeAnimacao = 1;
    private float delta = 0.8f;
    private float next = 0.8f;
    
    //spawn de animacoes:
    public Transform lugarExplosao1;
    public Transform lugarExplosao2;
    public Transform lugarExplosao3;
    public Transform lugarExplosao4;
    public Transform lugarFogo1;
    public Transform lugarFogo2;


    public bool playingExplosao1;
    public bool playingExplosao2;
    public bool pegandoFogo1;
    public bool pegandoFogo2;
    
    
    private void Start()
    {
        explosao1 = null;
        explosao2 = null;
        explosao3 = null;
        fogo1 = null;
        playingExplosao1 = false;
        playingExplosao2 = false;
        pegandoFogo1 = false;
        pegandoFogo2 = false;
    }


    void Update()
    {
        if (PlayerPrefs.GetInt("explosao1")== 1){
            vector1 = lugarExplosao1.position;
            vector1.z -= 0.1f;
            if (playingExplosao1 == false)
            {
                explosao1 = Instantiate(ExplosaoGrande, vector1, lugarExplosao1.rotation);
                playingExplosao1 = true;
            }
        }
        if (PlayerPrefs.GetInt("explosao3")== 1){
            vector1 = lugarExplosao1.position;
            vector1.z -= 0.1f;
            if (playingExplosao1 == false)
            {
                explosao1 = Instantiate(ExplosaoGrande, vector1, lugarExplosao1.rotation);
                playingExplosao1 = true;
            }
        }

        if (PlayerPrefs.GetInt("explosao2") == 1)
        {
            vector2 = lugarExplosao1.position;
            vector2.z -= 0.1f;
            
            vector3 = lugarExplosao2.position;
            vector3.z -= 0.1f;

            if (playingExplosao2 == false)
            {
                explosao2 = Instantiate(ExplosaoGrande, vector2, lugarExplosao1.rotation);
                explosao3 = Instantiate(ExplosaoPequena, vector3, lugarExplosao2.rotation);
                playingExplosao2 = true;
            }
        }
        if (PlayerPrefs.GetInt("explosao4") == 1)
        {
            vector2 = lugarExplosao1.position;
            vector2.z -= 0.1f;
            
            vector3 = lugarExplosao2.position;
            vector3.z -= 0.1f;

            if (playingExplosao2 == false)
            {
                explosao2 = Instantiate(ExplosaoGrande, vector2, lugarExplosao1.rotation);
                explosao3 = Instantiate(ExplosaoPequena, vector3, lugarExplosao2.rotation);
                playingExplosao2 = true;
            }
        }


        if (PlayerPrefs.GetInt("pegandoFogo1") == 1)
        {
            vector4 = lugarFogo1.position;
            vector4.z -= 0.1f;
            
            myTimeAnimacao += Time.deltaTime;

            if (myTimeAnimacao > next)
            {
                next = myTimeAnimacao + delta;
                fogo1 = Instantiate(Fogo, vector4, lugarFogo1.rotation);
                next -= myTimeAnimacao;
                myTimeAnimacao = 0f;
            }
        }

        if (PlayerPrefs.GetInt("pegandoFogo2") == 1)
        {
            vector5 = lugarFogo2.position;
            vector5.z -= 0.1f;
            
             myTimeAnimacao += Time.deltaTime;

             if (myTimeAnimacao > next)
             { 
                 next = myTimeAnimacao + delta;
                 fogo2 = Instantiate(Fogo, vector5, lugarFogo2.rotation);
                  next -= myTimeAnimacao;
                  myTimeAnimacao = 0f;
             }
            
        }
        if (PlayerPrefs.GetInt("explosaoFinal") == 1)
        {
            Vector3 v1 = lugarExplosao1.position;
            Vector3 v2 = lugarExplosao2.position;
            Vector3 v3 = lugarExplosao3.position;
            Vector3 v4 = lugarExplosao4.position;
            v1.z -= 0.1f;
            v2.z -= 0.1f;
            v3.z -= 0.1f;
            v4.z -= 0.1f;
            Instantiate(ExplosaoGrande, v1, lugarExplosao1.rotation);
            Instantiate(ExplosaoPequena, v2, lugarExplosao2.rotation);
            Instantiate(ExplosaoGrande, v3, lugarExplosao3.rotation);
            Instantiate(ExplosaoPequena, v4, lugarExplosao4.rotation);
            PlayerPrefs.SetInt("explosaoFinal", 0);
        }

        AtualizarFogoEexplosoes();
    }
    
    
    private void AtualizarFogoEexplosoes()
    {
       
        if (fogo1 != null)
        {
            vector4 = lugarFogo1.position;
            vector4.z -= 0.1f;
            fogo1.transform.position = vector4;
        }
        
        if (fogo2 != null)
        {                
            vector5 = lugarFogo2.position;
            vector5.z -= 0.1f;
            fogo2.transform.position = vector5;
        }

        if (explosao1 != null)
        {
            vector1 = lugarExplosao1.position;
            vector1.z -= 0.1f;
            explosao1.transform.position = vector1;
        }

        if (explosao2 != null)
        {
            vector2 = lugarExplosao1.position;
            vector2.z -= 0.1f;
            explosao2.transform.position = vector2;
        }

        if (explosao3 != null)
        {
            vector3 = lugarExplosao2.position;
            vector3.z -= 0.1f;
            explosao3.transform.position = vector3;
        }
    }
}