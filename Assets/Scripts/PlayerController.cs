using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text scoreText;
    public Text winText;

    private int score;
    private Rigidbody rb;

    private int numberOfPickUps = 8;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;

        SetCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        //Collecting Pick Ups
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            score += 1;

            SetCountText();
        }

        //Collecting Oposition of Pick Ups
        if (other.gameObject.CompareTag("Oposition of Pick Up"))
        {
            other.gameObject.SetActive(false);
            score -= 1;

            SetCountText();
        }
    }

    void SetCountText()
    {
        scoreText.text = "Count: " + score.ToString() + "/" + numberOfPickUps.ToString();
        if (score >= numberOfPickUps)
            winText.text = "You win!";
    }
}
