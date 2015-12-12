using UnityEngine;
using System.Collections;
using UnitySampleAssets._2D;

public class HUDScript : MonoBehaviour {
    
	// game font set-up
	public Font guiFont;
	public int fontSize;

	// GUI rect variables
	private int len;
	private Rect scoreBox;
	private Rect scoreFly;

	private int rectX, rectY, scoreBoxEnd;

	//Heads up Display
    float playerScore;
    float currentSpeed;

	// floating score tools
	float scoreMark;
	bool floatOn = false;
	int powerUpScore;
	float differential;
	
	// score popup set-up
	Transform player;

	void Start()
	{
		rectX = 20;
		rectY = 12;
	}

	// Update is called once per frame
	void Update ()
    {
        playerScore += (Time.deltaTime * 10);
        //currentSpeed = PlatformerCharacter2D.getMaxSpeed();

    }
    
    public void IncreaseScore(int amount)
    {
		player = GameObject.Find ("Player").transform;
        playerScore += amount;
		powerUpScore = amount;

		Debug.Log ("Power Up: " + powerUpScore);
//		scoreMark = Time.time;
		floatOn = true;

		string scoreString = powerUpScore.ToString();
//		int scoreMeasure = scoreString.Length;

		if (scoreBox != null) 
		{
			scoreFly = new Rect (scoreBoxEnd/2 - ((int)scoreString.Length*15), rectY, (int)scoreString.Length*18, 30);
			scoreFly.y += 40;

			differential = scoreFly.y - scoreBox.y;
		}

//		StartCoroutine("floatScore", amount);

    }

    void OnDisable()
    {
        PlayerPrefs.SetInt("Score", (int)(playerScore*10));
    }
    void OnGUI()
    {
//		style.font = guiFont;
		GUI.skin.font = guiFont;
//		fontSize = GUI.skin.font.fontSize;

		if (playerScore > 0)
        {
            GUI.contentColor = Color.yellow;
			GUI.backgroundColor = Color.black;
			GUI.skin.textArea.alignment = TextAnchor.UpperLeft;

//			GUI.contentColor = Color.white;
			GUI.skin.textArea.fontSize = 22;
//			GUI.skin.textArea.fontStyle = FontStyle.Bold;
        }
        else
        {
            GUI.contentColor = Color.red;
        }

		string score =  ((int)(playerScore * 10)).ToString();
		len = "Score: ".Length + score.Length;
		scoreBox = new Rect (rectX, rectY, (len * 14) + 2, 30);
		scoreBoxEnd = rectX + (len * 14) + 2;

		GUI.TextArea(scoreBox, "Score: " + (int)(playerScore * 10));

		if (floatOn) 
		{
			GUI.contentColor = Color.cyan;
			GUI.backgroundColor = Color.clear;
			GUI.skin.textField.fontSize = 24;
			GUI.skin.textField.alignment = TextAnchor.MiddleRight;

			Debug.Log("In floatOn");
			scoreFly.y -= 1;
			GUI.TextField(scoreFly, "+" + powerUpScore);

			GUI.color.a.Equals((scoreFly.y - scoreBox.y) / differential);

			if (scoreFly.y < scoreBox.y)
				floatOn = false;

		}
    }

	IEnumerator floatScore(int score)
	{
		while (scoreFly.y > 0) 
		{
			Debug.Log("Spawned ScoreFly: " + scoreFly.y);
			scoreFly.y -= 1;
			GUI.TextField (scoreFly, "score");
			yield return null;
		}
	}
}
