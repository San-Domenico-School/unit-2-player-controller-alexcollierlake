using UnityEngine;
using TMPro;

public class Resources : MonoBehaviour
{
    public TextMeshProUGUI resourceText;

    public GameObject gameOverCanvas; // Reference to the canvas displaying game over messages.

    private int aluminumCount = 0;
    private int magnesiumCount = 0;
    private int hydrogenCount = 0;
    private int oxygenCount = 0;
    private int waterCount = 0;

    private bool gameEnded = false;

    private void Start()
    {
        UpdateResourceText();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check the tag of the collided object
        string tag = collision.gameObject.tag;

        // Check and update the corresponding resource count
        if (tag == "Aluminum")
        {
            aluminumCount++;
        }
        else if (tag == "Magnesium")
        {
            magnesiumCount++;
        }
        else if (tag == "Hydrogen")
        {
            hydrogenCount++;
        }
        else if (tag == "Oxygen")
        {
            oxygenCount++;
        }
        else if (tag == "Water")
        {
            waterCount++;
        }

        if(!tag.Equals("Untagged")) Debug.Log("Line 46 Resource.cs Tag: " + tag);

        // Update the resource text
        UpdateResourceText();
    }

    private void UpdateResourceText()
    {
        if (resourceText != null)
        {
            // Update the TextMeshProUGUI text to display the collected resources
            string resourceList = "Resources Collected:\n";
            resourceList += "Aluminum: " + aluminumCount + "\n";
            resourceList += "Magnesium: " + magnesiumCount + "\n";
            resourceList += "Hydrogen: " + hydrogenCount + "\n";
            resourceList += "Oxygen: " + oxygenCount + "\n";
            resourceList += "Water: " + waterCount + "\n";

            resourceText.text = resourceList;
        }
    }

    public void CheckGameEnd()
    {
        if (!gameEnded)
        {
            if (aluminumCount > 0 && magnesiumCount > 0 && hydrogenCount > 0 && oxygenCount > 0 && waterCount > 0)
            {
                // Player won
                gameOverCanvas.SetActive(true); // Display the game over canvas
                gameOverCanvas.GetComponentInChildren<TextMeshProUGUI>().text = "You Won!";
                gameEnded = true;
            }
            else
            {
                // Player lost
                gameOverCanvas.SetActive(true); // Display the game over canvas
                gameOverCanvas.GetComponentInChildren<TextMeshProUGUI>().text = "You Lost";
                gameEnded = true;
            }
        }
    }

    // Add this method to handle collisions with the "GameEnd" trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GameEnd"))
        {
            CheckGameEnd();
        }
    }
}