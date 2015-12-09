using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverScript : MonoBehaviour {

    int score = 0;
	public Text scoreText;

	void Start ()
    {
        score = PlayerPrefs.GetInt("Score");
		scoreText = GameObject.Find("Canvas").GetComponentInChildren<Text>();
		scoreText.text = "SCORE     " + score;

    }
}
