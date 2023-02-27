
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControladroFimDeJogo : MonoBehaviour
{
    public Button jogarDeNovo;
    public Button voltarMenu;
    
    public TextMeshProUGUI scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        int tempoRestante = PlayerPrefs.GetInt("tempoRestante");
        int tempoPartida = PlayerPrefs.GetInt("tempoInicial");
        int tempoSpawn = PlayerPrefs.GetInt("tempoSpawn");
        int pontos = PlayerPrefs.GetInt("pontos");
        int vidaPlayer = PlayerPrefs.GetInt("vidaPlayer");
        int numeroDeInimigosPorSpawn = PlayerPrefs.GetInt("numeroDeInimigosPorSpawn");

        scoreText.SetText("Você perdeu!\n" +
                          "Sua pontuação foi de " + pontos + " pontos.\n" +
                          "Tempo restante: " + tempoRestante / 60 + " minutos e " + tempoRestante % 60 +
                          " segundos.\n" +
                          "Vida restante: " + vidaPlayer + "/100\n" +
                          "Se quiser começar um jogo novo, a partida tera duração de: " +
                          tempoPartida / 60 + " minutos e " +
                          tempoPartida % 60 + " segundos. \nO numero de inimigos por orda será de " + numeroDeInimigosPorSpawn +
                          " inimigos,e o tempo entre as ordas de inimigos será de " + tempoSpawn + " segundos.");
        Button btnJogarDeNovo = jogarDeNovo.GetComponent<Button>();
        btnJogarDeNovo.onClick.AddListener(jogarDeNovo1);
        
        Button btnvoltarMenu = voltarMenu.GetComponent<Button>();
        btnvoltarMenu.onClick.AddListener(btnvoltarMenu1);
    }

     void btnvoltarMenu1()
     {
         SceneManager.LoadScene("TelaInicial");
     }

    void jogarDeNovo1()
    {
        SceneManager.LoadScene("Game");
    }
}
