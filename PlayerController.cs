using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    private int count;
    public float speed;
    public Text countText;
    public Text winText;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        setCountText();
        winText.text = "";
    }

    void FixedUpdate () //physics operations
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            setCountText();
        }
    }

    void setCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 10)
            winText.text = "You Win!";
    }
}
