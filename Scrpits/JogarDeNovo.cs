using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JogarDeNovo : MonoBehaviour
{
    public Button yourButton;
    void Start () {
        
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick(){
        
        SceneManager.LoadScene("Game");
    }
}
