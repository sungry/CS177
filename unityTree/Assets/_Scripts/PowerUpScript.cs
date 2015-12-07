using UnityEngine;
using System.Collections;

public class PowerUpScript : MonoBehaviour {

    HUDScript hud;

	private float destructOffset = 1.0f;
	private bool selfDestruct = false;
	private float destructSequence;
	private float grow;

    void OnTriggerEnter2D(Collider2D other)
    //void OnCollissionExit2D(Collider2D other)
    {
        if(other.tag =="Player")
        {
            hud = GameObject.Find("Main Camera").GetComponent<HUDScript>();
            hud.IncreaseScore(100);

			selfDestruct = true;

			destructSequence = Time.time;
			grow = this.transform.localScale.x * 0.1f;
 
        }
    }

	private void Update()
	{
		if (selfDestruct) 
		{

//			this.transform.localScale *= new Vector3(1.1, 1.1, 0);
			this.transform.localScale += new Vector3(grow, grow, 0);

			if (Time.time > destructSequence + destructOffset)
			{
				Destroy(this.gameObject);
			}
		}

	}
}
