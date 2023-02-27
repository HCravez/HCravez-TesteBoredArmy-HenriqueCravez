using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Configuracao : MonoBehaviour
{
    // Start is called before the first frame update
    public Button voltar;

    public Slider TempoInicialSlider;
    public Slider TempoSpawnSlider;
    public Slider NumeroDeInimigosPorSpawn;

    private int tempoInicial;
    private int tempoSpawn;
    private int numeroDeInimigosPorSpawn;
    void Start()
    {
        tempoInicial = PlayerPrefs.GetInt("tempoInicial");
        tempoSpawn = PlayerPrefs.GetInt("tempoSpawn");
        numeroDeInimigosPorSpawn = PlayerPrefs.GetInt("numeroDeInimigosPorSpawn");
        
        TempoInicialSlider.value = tempoInicial;
        TempoSpawnSlider.value = tempoSpawn;
        NumeroDeInimigosPorSpawn.value = numeroDeInimigosPorSpawn;
        
        Button btn = voltar.GetComponent<Button>();
        btn.onClick.AddListener(ButtonClicked);
    }


    void ButtonClicked()
    {
        tempoInicial = (int) TempoInicialSlider.value;
        tempoSpawn = (int) TempoSpawnSlider.value;
        numeroDeInimigosPorSpawn = (int)NumeroDeInimigosPorSpawn.value;
        PlayerPrefs.SetInt("tempoInicial", tempoInicial);
        PlayerPrefs.SetInt("tempoSpawn", tempoSpawn);
        PlayerPrefs.SetInt("numeroDeInimigosPorSpawn", numeroDeInimigosPorSpawn);
        PlayerPrefs.SetInt("pontos",0);
        PlayerPrefs.SetInt("vidaPlayer",100);
        PlayerPrefs.SetInt("tempoRestante",tempoInicial);
        PlayerPrefs.Save();
        SceneManager.LoadScene("TelaInicial");
    }
}
