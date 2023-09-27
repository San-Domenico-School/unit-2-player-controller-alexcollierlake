using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scorekeeper : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreboardText; // Reference to the Scoreboard TextMeshProUGUI GameObject

    public GameObject gameOverCanvas;
    private float energyLevel;                                      // Player's current score
    private int penalty = 20;                                 // Penalty for running into an obstacle

    public static Scorekeeper Instance;                       // This script has a public static reference to itself so that other scripts can access it from anywhere without needing to find a reference to it

   
    private bool isGameOver = false; // Flag to track if the game is over

    void Start()
    {
        energyLevel = 100.0f;
        // Start a repeating timer to decrease energy every 5 seconds
        InvokeRepeating("DecreaseEnergyPeriodically", 5f, 5f);
        CheckGameEnd();
        
    }

    // Called during the initialization of a script/component.
    void Awake()
    {
        // This is a common approach to handling a class with a reference to itself.
        // If instance variable doesn't exist, assign this object to it
        if (Instance == null)
            Instance = this;
        // Otherwise, if the instance variable does exist, but it isn't this object, destroy this object.
        // This is useful so that we cannot have more than one GameManager object in a scene at a time.
        else if (Instance != this)
            Destroy(this.gameObject);
    }

    // Inputs vertical input value received from the playerController script to an exponential
    // function whose values range from 0.00 to 0.35 which is then added to the score before
    // calling the DisplayScore method
    public void AddToScore(float inputFromPlayer)
    {
        // Calculate the score increase using an exponential function
        float scoreIncrease = Mathf.Pow(inputFromPlayer, 2) * 0.05f;

        // Add the score increase to the current score
        energyLevel += scoreIncrease;

        // Call the DisplayScore method to update the UI
        DisplayScore();
    }

    // Subtracts penalty from the score to no less than zero when the player runs into an obstacle.
    // before calling the DisplayScore method
    public void SubtractFromScore()
    {
        // Subtract the penalty from the score, ensuring it doesn't go below zero
        energyLevel = Mathf.Max(0, energyLevel - penalty);

        // Call the DisplayScore method to update the UI
        DisplayScore();
    }

    // Displays score to UI rounded to the nearest integer
    public void DisplayScore()
    {
        // Round the score to the nearest integer
        int roundedScore = Mathf.RoundToInt(energyLevel);

        // Update the TextMeshProUGUI text with the new score
        scoreboardText.text = "Energy: " + roundedScore.ToString();
    }

    // Method to decrease energy periodically
    private void DecreaseEnergyPeriodically()
    {
        energyLevel -= 15;
        DisplayScore();

        CheckGameEnd();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Energy"))
        {
            Debug.Log("energy");
            energyLevel += 30;
           
            
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            energyLevel -= 20;
            
        }

        DisplayScore();

        CheckGameEnd();
    }

    

    private void CheckGameEnd()
    {
        if (!isGameOver && energyLevel <= 0)
        {
            isGameOver = true;
            // You can add game over logic here, such as displaying a game over screen or performing other actions.
            Debug.Log("Game Over");

            // Call a method to handle the game over screen
            HandleGameOver();
        }
    }

    // Method to handle the game over screen
    private void HandleGameOver()
    {
      

        // Stop player movement (you need to replace "PlayerController" with the actual name of your player movement script)
        PlayerController playerController = GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.StopMovement(); // Implement this method in your player movement script to stop movement.
        }

        // Display "You Lost" on a canvas (you need to replace "gameOverCanvas" with the actual name of your canvas GameObject)
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true);
            gameOverCanvas.GetComponentInChildren<TextMeshProUGUI>().text = "You Lost";
        }
    }

}