 using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Shooter : MonoBehaviour
{
    private float Velocidade = 1.5f;

    private int vida = 100;
    public Slider sliderVida;
    private float time = 0.0f;
    private float interpolationPeriod = 0.002f;
    
    public SpriteRenderer SpriteRenderer;
    public Sprite spriteDanificado;
    public Sprite spriteQuaseMorto;
    public Sprite spriteMorreu;
    public Sprite spriteFullvida;
    
    private GameObject player;
    public GameObject triggerArea;
    
    private bool vivo; 
    private bool Trigger;
    private float TimeOnTrigger;
    
    public GameObject EnemyBullet;
    public GameObject Canon;
    public GameObject ExplosaoPequena;
    public GameObject ExplosaoGrande;
    public GameObject Fogo;

    public float myTime = 5;
    public float fireDelta = 1;
    private float nextFire = 1;
    
    
    //spawn de animacoes:
    public Transform explosaoMorte1;
    public Transform explosaoMorte2;
    public Transform explosaoMorte3;
    public Transform explosaoMorte4;
    public Transform fogo1;
    public Transform fogo2;
    
    //privates:
    private float myTimeAnimacao = 1;
    private float delta = 0.8f;
    private float next = 0.8f;
    private bool JaExplosao1 = true;
    private bool JaExplosao2 = true;
    private GameObject fogoNoNavio;
    private GameObject muitoFogoNoNavio;
    private GameObject explosao1;
    private GameObject explosao2;
    private GameObject explosao3;
    private GameObject enemyBullet;
    
    
    // Start is called before the first frame update
    void Start()
    {
        sliderVida.value = vida;
        vivo = true;
        Trigger = false;
        player = GameObject.Find("Player");
        
        fogoNoNavio = null;
        muitoFogoNoNavio = null; 
    }

    // Update is called once per frame
    void Update()
    {
        Movimenta();

        CheckDetorir();
        AtualizarFogoEexplosoes();
    }

    private void AtualizarFogoEexplosoes()
    {
       
        if (fogoNoNavio != null)
        {
            fogoNoNavio.transform.position = fogo1.position;
        }
        
        if (muitoFogoNoNavio != null)
        {
            muitoFogoNoNavio.transform.position = fogo2.position;
        }

        if (explosao1 != null)
        {
            explosao1.transform.position = explosaoMorte1.position;
        }
        if (explosao2 != null)
        {
            explosao2.transform.position = explosaoMorte1.position;
        }
        if (explosao3 != null)
        {
            explosao3.transform.position = explosaoMorte2.position;
        }
    }

    public void Movimenta()
    {

        if (vivo)
        { 
            if(!Trigger){
                transform.position += transform.up * Time.deltaTime * Velocidade; //Seguir em frente

                time += Time.deltaTime;

                if (time >= interpolationPeriod)
                {
                    bool randomBool = Random.value > 0.5;
                    if (randomBool)
                    {
                        transform.Rotate(0, 0, -3); //Rodar para a direita
                    }
                    else
                    {
                        transform.Rotate(0, 0, 3); //Rodar para a esquerda
                    }
                }

            }
            else if(Time.deltaTime < TimeOnTrigger )
            {
                ApontarNaDirecao();
                Atirar();
            } 
            else
            {
                Trigger = false;
            }
        }       
    }

    public void CheckDetorir()
    {
        if (66 < vida )
        {
            SpriteRenderer.sprite = spriteFullvida;
            
        }
        else if (33 < vida && vida < 66)
        {
            SpriteRenderer.sprite = spriteDanificado;
            myTimeAnimacao += Time.deltaTime;

            if (myTimeAnimacao > next)
            {
                next = myTimeAnimacao + delta;
                fogoNoNavio = Instantiate(Fogo, fogo1.position, fogo1.rotation);
                next -= myTimeAnimacao;
                myTimeAnimacao = 0f;
            }

            if (JaExplosao1)
            {
                explosao1 = Instantiate(ExplosaoGrande, explosaoMorte1.position, explosaoMorte1.rotation);
                JaExplosao1 = false;
            }
        }
        else if (1 < vida && vida < 33)
        {
            SpriteRenderer.sprite = spriteQuaseMorto;
            myTimeAnimacao += Time.deltaTime;

            if (myTimeAnimacao > next)
            {
                next = myTimeAnimacao + delta;
                muitoFogoNoNavio = Instantiate(Fogo, fogo2.position, fogo2.rotation);
                                
                next -= myTimeAnimacao;
                myTimeAnimacao = 0f;
            }
            if (JaExplosao2)
            {
                explosao2 = Instantiate(ExplosaoGrande, explosaoMorte1.position, explosaoMorte1.rotation);
                explosao3 = Instantiate(ExplosaoPequena, explosaoMorte2.position, explosaoMorte2.rotation);
                JaExplosao2 = false;
            }
        }
        else if (vida <= 0 && vivo)
        {
            Morrer();
        }
        sliderVida.value = vida;
    }

 
    private void Morrer()
    {
        SpriteRenderer.sprite = spriteMorreu;
        vivo = false;
        Instantiate(ExplosaoGrande, explosaoMorte1.position, explosaoMorte1.rotation);
        Instantiate(ExplosaoPequena, explosaoMorte2.position, explosaoMorte2.rotation);
        Instantiate(ExplosaoGrande, explosaoMorte3.position, explosaoMorte3.rotation);
        Instantiate(ExplosaoPequena, explosaoMorte4.position, explosaoMorte4.rotation);
        Destroy(triggerArea);
    }
    
    void OnCollisionEnter2D (Collision2D Objeto2) {	
        
        if(Objeto2.gameObject.name == "cannonBall(Clone)" )	
        {	
            vida = vida - 30;	
            PlayerPrefs.SetInt("pontos",PlayerPrefs.GetInt("pontos") + 20);
            if (vida <= 25)
            {
                vida = vida - 30;
                PlayerPrefs.SetInt("pontos",PlayerPrefs.GetInt("pontos") + 50);   
            }
        }
        if(Objeto2.gameObject.name == "Player" && vivo)	
        {
            PlayerPrefs.SetInt("vidaPlayer",PlayerPrefs.GetInt("vidaPlayer") - 20);
        }
        if (Objeto2.gameObject.tag == "ILHAS")
        {
            transform.rotation = Quaternion.Inverse(transform.rotation);
        }
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "Player"  && vivo )
        {
            Trigger = true;
            TimeOnTrigger = Time.deltaTime + 5;
        }
    }

    private void ApontarNaDirecao()
    { 
        Vector3 vectorToTarget = player.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 40 );
    }
    
    private void Atirar()
    {
        myTime += Time.deltaTime;
        if (myTime > nextFire) 
        {
            nextFire = myTime + fireDelta;
            enemyBullet = Instantiate(EnemyBullet, Canon.transform.position, Canon.transform.rotation);
            GameObject explosao = Instantiate(ExplosaoPequena, Canon.transform.position, Canon.transform.rotation);
            explosao.transform.position = Canon.transform.position;
            nextFire -= myTime;
            myTime = 0.0F;
        }
        if (enemyBullet != null)
        {
            enemyBullet.transform.position += transform.up * Time.deltaTime * 6f;
        }
    }
}
