using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int cardAttribute; // For example: health or power
    public string cardName;
    public Color backgroundColor;

    public TextMeshProUGUI cardNameDisplay;
    public TextMeshProUGUI cardAttributeDisplay;
    public Image cardBackground;


    public void ChangeCardName(string newName)
    {
        cardName = newName;
        cardNameDisplay.text = cardName; // Update UI
    }

    public void RandomizeCard()
    {
        // Generate a random attribute value between 1 and 100
        cardAttribute = Random.Range(1, 101);
        cardAttributeDisplay.text = cardAttribute.ToString(); // Update UI

        // Generate a random name (from a predefined list of names)
        string[] possibleNames = { "Dragon", "Phoenix", "Wizard", "Knight", "Elf", "Orc" };
        cardName = possibleNames[Random.Range(0, possibleNames.Length)];
        cardNameDisplay.text = cardName; // Update UI

        // Generate a random background color
        backgroundColor = new Color(
            Random.Range(0f, 1f), // Random red value
            Random.Range(0f, 1f), // Random green value
            Random.Range(0f, 1f)  // Random blue value
        );
        cardBackground.color = backgroundColor; // Update UI
    }

    public void ChangeName()
    {
        string[] possibleNames = { "Dragon", "Phoenix", "Knight", "Wizard", "Elf", "Orc" };
        cardName = possibleNames[Random.Range(0, possibleNames.Length)];
        cardNameDisplay.text = cardName; // Update the UI text element
    }

    public void ChangeAttribute(int amount)
    {
        cardAttribute += amount;
        cardAttributeDisplay.text = cardAttribute.ToString(); // Update UI
    }

    public void ChangeBackgroundColor()
    {
        // Generate a random color
        backgroundColor = new Color(
            Random.Range(0f, 1f), // Random red value
            Random.Range(0f, 1f), // Random green value
            Random.Range(0f, 1f)  // Random blue value
        );
        cardBackground.color = backgroundColor; // Apply the new color to the card's background
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ChangeAttribute(1);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ChangeAttribute(-1);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeCardName("RandomName");
        }
    }
}
