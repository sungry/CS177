using UnityEngine;
using System.Collections;
using UnitySampleAssets._2D;

public class HUDScript : MonoBehaviour {
    
	// game font set-up
	public Font guiFont;
	public int fontSize;

//	GUIStyle style = new GUIStyle ();

	//Heads up Display
    float playerScore;
    float currentSpeed;
	
	// score popup set-up
	Transform player;

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
    }

    void OnDisable()
    {
        PlayerPrefs.SetInt("Score", (int)(playerScore*10));
    }
    void OnGUI()
    {
//		style.font = guiFont;
		GUI.skin.font = guiFont;
		fontSize = GUI.skin.font.fontSize;

		if (playerScore > 0)
        {
            GUI.contentColor = Color.yellow;
//			GUI.contentColor = Color.white;
			GUI.skin.textArea.fontSize = 22;
//			GUI.skin.textArea.fontStyle = FontStyle.Bold;
        }
        else
        {
            GUI.contentColor = Color.red;
        }

		string score =  ((int)(playerScore * 10)).ToString();
		int len = "Score: ".Length + score.Length;
        GUI.TextArea(new Rect(20, 12, len*14, 30), "Score: " + (int)(playerScore * 10));
    }

	void floatScore()
	{

	}
}
