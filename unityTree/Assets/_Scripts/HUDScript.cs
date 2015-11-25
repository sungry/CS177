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
        playerScore += Time.deltaTime;
        //currentSpeed = PlatformerCharacter2D.getMaxSpeed();
    }
    
    public void IncreaseScore(int amount)
    {
        playerScore += amount;
    }

    void OnDisable()
    {
        PlayerPrefs.SetInt("Score", (int)(playerScore * 100));
    }
    void OnGUI()
    {
        if (playerScore > 0)
        {
            GUI.contentColor = Color.black;
        }
        else
        {
            GUI.contentColor = Color.red;
        }
            //position 10, 10 100 wide 30 tall
        GUI.Label(new Rect(10, 10, 300, 30), "Score: " + (int)(playerScore * 10) + "    Time: " + Time.time 
            + "     Speed: ");
    }
}
