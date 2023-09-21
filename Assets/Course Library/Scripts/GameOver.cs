using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameOver : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI gameOverText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check for the game over condition in the Update method.
        if (Input.GetKeyDown(KeyCode.Escape)) // You can change the condition as needed.
        {
            EndGame();
        }
    }

    void EndGame()
    {
        // Stop the game by setting the Time.timeScale to 0.
        Time.timeScale = 0;

        // Display the "YOU LOST" message using TextMeshPro.
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = "YOU LOST";
    }
}
