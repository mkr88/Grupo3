using UnityEngine;
using UnityEngine.UI; // Still needed for the Button component
using TMPro; // Add this for TextMeshPro components
using System.Collections.Generic; // For using List

public class TextCycler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI displayText; // Change to TextMeshProUGUI for TMP text
    [SerializeField] private Button rightButton; // Button to go to the next text
    [SerializeField] private Button leftButton; // Button to go to the previous text
    [SerializeField] private List<string> texts; // List of texts to cycle through

    private int currentIndex = 0; // Current index of the displayed text in the list

    void Start()
    {
        if (texts.Count > 0)
        {
            UpdateDisplayedText();
        }
        rightButton.onClick.AddListener(MoveNext);
        if (leftButton != null)
        {
            leftButton.onClick.AddListener(MovePrevious);
        }
    }

    private void UpdateDisplayedText()
    {
        if (currentIndex >= 0 && currentIndex < texts.Count)
        {
            displayText.text = texts[currentIndex]; // This will now update a TMP text element
        }
    }

    public void MoveNext()
    {
        if (currentIndex < texts.Count - 1)
        {
            currentIndex++;
            UpdateDisplayedText();
        }
    }

    public void MovePrevious()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            UpdateDisplayedText();
        }
    }
}
