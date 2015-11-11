using UnityEngine;
using System.Collections;

public class HUDScript : MonoBehaviour {
    //Heads up Display
    float playerScore;

	
	// Update is called once per frame
	void Update ()
    {
        playerScore += Time.deltaTime;    
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
        GUI.Label(new Rect(10, 10, 100, 30), "Score: " + (int)(playerScore * 100));
    }
}
