using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    
    //Variaveis que cuidam da vida e da pontuação do jogador:
    public int vida;
    public int pontos;
    
    //Varivaeis que controlam o tempo
    private float tempoRestante;
    private float tempoInicial;

    //Varivaies de movimento do jogador
    private int playerSpeed = 4;
    int turnSpeed = 200;

    //UI
    public Slider vidaUI;
    public Slider vidaNoBarcoSilder;
    public TextMeshProUGUI scoreAndTimeText;
    private string stringTempoInicialUI;

    //Sprites
    public SpriteRenderer SpriteRenderer;
    public Sprite spriteDanificado;
    public Sprite spriteQuaseMorto;
    public Sprite spriteMorreu;

    //privates:
    private bool JaExplosao1 = true;
    private bool JaExplosao2 = true;
    private bool JaExplosao3 = true;
    private bool JaExplosao4 = true;
    private bool JaPegandofogo1 = true;
    private bool JaPegandofogo2 = true;
    private bool morto;

    //Inicialização do jogador
    void Start()
    {
        vidaUI.value = vida;
        vidaNoBarcoSilder.value = vida;
        PlayerPrefs.SetInt("pontos",0);
        PlayerPrefs.SetInt("vidaPlayer",100);
        tempoInicial = PlayerPrefs.GetInt("tempoInicial");
        pontos = 0;
        vida = 100;
        tempoRestante = tempoInicial;

        PlayerPrefs.SetInt("explosao1",0);
        PlayerPrefs.SetInt("explosao2",0);
        PlayerPrefs.SetInt("explosao3",0);
        PlayerPrefs.SetInt("explosao4",0);
        PlayerPrefs.SetInt("pegandoFogo1",0);
        PlayerPrefs.SetInt("pegandoFogo2",0);
        PlayerPrefs.SetInt("explosaoFinal",0);

        SetUI();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (morto == false)
        {
            ControlesDeMovimento();   //controla movimento
        }
        
        CheckDetorir();               //Controla, vida, explosoes, e sprites
        
        AtualizarUI();                 //UI
         
        CheckGameOver();               //Controla se ja é fim de jogo
    }
    private void CheckGameOver()
    {
        tempoRestante -= Time.deltaTime;        //incrementa o Tempo restante
        if (vida <= 0 || tempoRestante <= 0)
        {
            GameOver();
        }
    }

    private void ControlesDeMovimento()
    {
        if((Input.GetKey(KeyCode.D))) //Right arrow key to turn right
        {
            transform.Rotate(-Vector3.forward *turnSpeed* Time.deltaTime);
        }
 
        if((Input.GetKey(KeyCode.A)))//Left arrow key to turn left
        { 
            transform.Rotate(Vector3.forward *turnSpeed* Time.deltaTime);
        }
 
        if((Input.GetKey(KeyCode.W)))//Press up arrow key to move forward on the Y AXIS
        {
            transform.Translate(0,playerSpeed * Time.deltaTime,0);
        }
        if(Input.GetKey(KeyCode.S))//Press up arrow key to move forward on the Y AXIS
        {
            transform.Translate(0,-playerSpeed * Time.deltaTime,0);
        }
    }

    public void CheckDetorir()
    {
        vida = PlayerPrefs.GetInt("vidaPlayer");
        if ( vida == 80)
        {
            
            if (JaExplosao3)
            {
                PlayerPrefs.SetInt("explosao3",1);
                JaExplosao3 = false;
            }
        }
        else if (vida == 60 )
        {
            SpriteRenderer.sprite = spriteDanificado;
            if (JaPegandofogo1)
            {
                PlayerPrefs.SetInt("pegandoFogo1",1);
                JaPegandofogo1 = false;
            }

            if (JaExplosao1)
            {
                PlayerPrefs.SetInt("explosao1",1);
                JaExplosao1 = false;
            }
        }
        else if (vida == 40)
        {
            
            if (JaExplosao4)
            {
                PlayerPrefs.SetInt("explosao4",1);
                JaExplosao4 = false;
            }
        }
        else if (vida == 20)
        {
            SpriteRenderer.sprite = spriteQuaseMorto;
            if (JaPegandofogo2)
            {
                PlayerPrefs.SetInt("pegandoFogo2",1);
                JaPegandofogo2 = false;
            }
            if (JaExplosao2)
            {
                PlayerPrefs.SetInt("explosao2",1);
                JaExplosao2 = false;
            }
        }
        else if (vida <= 0)
        {
            SpriteRenderer.sprite = spriteMorreu;
        }
        vidaUI.value = vida;
        vidaNoBarcoSilder.value = vida;
    }
    
    public void SetUI()
    {
        float minutoInicialUI = Mathf.FloorToInt(tempoInicial / 60); 
        float segundoInicialUI = Mathf.FloorToInt(tempoInicial % 60);
        stringTempoInicialUI = string.Format("{0:00}:{1:00}", minutoInicialUI, segundoInicialUI);
    }
    public void AtualizarUI()
    {
        pontos = PlayerPrefs.GetInt("pontos");
        tempoRestante -= Time.deltaTime;
        float minutosRestantes = Mathf.FloorToInt(tempoRestante / 60);
        float segundosRestantes = Mathf.FloorToInt(tempoRestante % 60);
        float milliSegundosRestantes = (tempoRestante % 1) * 10;
        string stringTempoRestante = string.Format("{0:00}:{1:00}:{2:0}", minutosRestantes, segundosRestantes, milliSegundosRestantes);
        scoreAndTimeText.text = "Pontos: "+ pontos +"   Tempo restante: "+ stringTempoRestante + "/" + stringTempoInicialUI;
    }

    public void GameOver()
    {
        PlayerPrefs.SetInt("explosaoFinal", 1);

        PlayerPrefs.SetInt("pontos", pontos);
        PlayerPrefs.SetInt("vidaPlayer", vida);
        PlayerPrefs.SetInt("tempoRestante", (int)tempoRestante);
        morto = true;
        SceneManager.LoadSceneAsync("FimDeJogo");
    }
}

