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
        }
        else
        {
            GUI.contentColor = Color.red;
        }
        //position 10, 10 300 wide 30 tall
        GUI.Label(new Rect(30, 15, 300, 50), "Score: " + (int)(playerScore * 10));

    }

	void floatScore()
	{

	}
}
