using UnityEngine;
using System.Collections;
using UnitySampleAssets._2D;

public class HUDScript : MonoBehaviour {
    //Heads up Display
    float playerScore;
    float currentSpeed;
	
	// Update is called once per frame
	void Update ()
    {
        playerScore += (Time.deltaTime * 10);
        //currentSpeed = PlatformerCharacter2D.getMaxSpeed();
    }
    
    public void IncreaseScore(int amount)
    {
        playerScore += amount;
    }

    void OnDisable()
    {
        PlayerPrefs.SetInt("Score", (int)(playerScore*10));
    }
    void OnGUI()
    {
        if (playerScore > 0)
        {
            GUI.contentColor = Color.white;
			GUI.skin.textArea.fontSize = 22;
			GUI.skin.textArea.fontStyle = FontStyle.Bold;
        }
        else
        {
            GUI.contentColor = Color.red;
        }
		string score =  ((int)(playerScore * 10)).ToString();
		int len = "Score: ".Length + score.Length;
        GUI.TextArea(new Rect(10, 10, len*12, 30), "Score: " + (int)(playerScore * 10));
    }
}
