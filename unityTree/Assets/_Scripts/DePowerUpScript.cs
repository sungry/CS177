using UnityEngine;
using System.Collections;

public class DePowerUpScript : MonoBehaviour {

    HUDScript hud;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            hud = GameObject.Find("Main Camera").GetComponent<HUDScript>();
            hud.IncreaseScore(-5);
            Destroy(this.gameObject);
        }
    }
}