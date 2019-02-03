using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MenuSystem : MonoBehaviour {

    public Text scoreText;

    private int score;

    void Start()
    {
        score = PlayerPrefs.GetInt("CurrentScore");
        scoreText.text = "You scored " + score.ToString() + " points!";
    }

	public void Play()
    {
        SceneManager.LoadScene("Level");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
