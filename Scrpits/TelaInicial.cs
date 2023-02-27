using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TelaInicial : MonoBehaviour
{
    public Button Jogar;
    public Button Configuracoes;
    public TextMeshProUGUI ConfiguracoesAtuais;
    
    // Start is called before the first frame update
    void Start()
    {
        
        int tempoInicial = PlayerPrefs.GetInt("tempoInicial");
        int tempoSpawn = PlayerPrefs.GetInt("tempoSpawn");
        int numeroDeInimigosPorSpawn = PlayerPrefs.GetInt("numeroDeInimigosPorSpawn");

        int min = tempoInicial  % 3600 / 60;
        int seg = tempoInicial % 60;
        string ConfiguracoesAtuaisText = "Configurações iniciais: \n" +
                                         "O Tempo da partida é de : " + min + "min e "+ seg +"seg \n" +
                                         "O numero de inimigos por orda é de "+ numeroDeInimigosPorSpawn+ " inimigos.\n"+
                                         "O Tempo entre as ordas de inimigos: "+ tempoSpawn + " segundos.\n";
        ConfiguracoesAtuais.text = ConfiguracoesAtuaisText;


        Button btnJogar = Jogar.GetComponent<Button>();
        btnJogar.onClick.AddListener(() => IrJogar(tempoInicial, tempoSpawn, numeroDeInimigosPorSpawn));
        
        Button btnConfiguracoes = Configuracoes.GetComponent<Button>();
        btnConfiguracoes.onClick.AddListener(() => irConfiguracoes(tempoInicial, tempoSpawn, numeroDeInimigosPorSpawn));
        
        
    }

    void IrJogar(int tempoInicial, int tempoSpawn, int numeroDeInimigosPorSpawn)
    {
        PlayerPrefs.SetInt("tempoInicial", tempoInicial);
        PlayerPrefs.SetInt("tempoSpawn", tempoSpawn);
        PlayerPrefs.SetInt("numeroDeInimigosPorSpawn", numeroDeInimigosPorSpawn);
        PlayerPrefs.SetInt("pontos",0);
        PlayerPrefs.SetInt("vidaPlayer",100);
        PlayerPrefs.SetInt("tempoRestante",tempoInicial);
        
        SceneManager.LoadScene("Game");
    }

    void irConfiguracoes(int tempoInicial, int tempoSpawn, int numeroDeInimigosPorSpawn)
    {
        PlayerPrefs.SetInt("tempoInicial", tempoInicial);
        PlayerPrefs.SetInt("tempoSpawn", tempoSpawn);
        PlayerPrefs.SetInt("numeroDeInimigosPorSpawn", numeroDeInimigosPorSpawn);
        PlayerPrefs.SetInt("pontos",0);
        PlayerPrefs.SetInt("vidaPlayer",100);
        PlayerPrefs.SetInt("tempoRestante",tempoInicial);

        SceneManager.LoadScene("Configuracoes");
    }
}