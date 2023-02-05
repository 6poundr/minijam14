using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;



public class GameOverScreen : MonoBehaviour
{
    public TMP_Text SnakesText;

    public void Setup(int score)
    {
        SnakesText.text = score.ToString();
    }
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void show(int snakesEaten)
    {
        SnakesText.text = "SNAKES EATEN: " + snakesEaten;
        gameObject.SetActive(true);

    }

    public void RestartButton()  {
        SceneManager.LoadScene("GameMap");
    }

    public void ExitButton()  {
        SceneManager.LoadScene("MainMenu");

    }
}
