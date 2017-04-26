using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText, scoreText, winText;

    private int score;
    private Rigidbody rb;

    private int numberOfPickUps = 8;
    private int numberOfPickUpsPicked;
    private bool gameGoal = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        numberOfPickUpsPicked = 0;

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
            numberOfPickUpsPicked += 1;

            SetCountText();
        }

        //Collecting Oposition of Pick Ups
        if (other.gameObject.CompareTag("Oposition of Pick Up"))
        {
            other.gameObject.SetActive(false);
            score -= 1;

            SetCountText();
        }

        //Finishing Game
        if (other.gameObject.CompareTag("Goal"))
        {
            other.gameObject.SetActive(false);
            gameGoal = true;

            SetCountText();
        }

    }

    void SetCountText()
    {
        countText.text = numberOfPickUpsPicked.ToString() + "/" + numberOfPickUps.ToString();
        scoreText.text = "Score: " + score.ToString();
        if (gameGoal == true && score >= numberOfPickUps / 2)
            winText.text = "You won!";
        if (gameGoal == true && score <= numberOfPickUps / 2)
            winText.text = "You lost!";
    }
}
