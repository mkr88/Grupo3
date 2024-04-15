using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    [SerializeField] private Button leftBtn;
    [SerializeField] private Button rightBtn;
    [SerializeField] private Image displayImage; // The UI element to display the selected image in a larger view
    [SerializeField] private List<Image> sideImages; // The UI elements for the smaller side images
    [SerializeField] private List<Sprite> images; // Assuming you're using Sprites for your images

    private int currentIndex = 0; // To keep track of the currently displayed image

    private void Start()
    {
        UpdateDisplayedImage();
        UpdateSideImages();
    }

    public void MoveLeft()
    {
        if (currentIndex > 0) // Make sure the index is within bounds
        {
            currentIndex--;
            UpdateDisplayedImage();
            UpdateSideImages();
        }
    }

    public void MoveRight()
    {
        if (currentIndex < images.Count - 1) // Make sure the index doesn't exceed the list
        {
            currentIndex++;
            UpdateDisplayedImage();
            UpdateSideImages();
        }
    }

    private void UpdateDisplayedImage()
    {
        if (images != null && images.Count > 0 && currentIndex >= 0 && currentIndex < images.Count)
        {
            displayImage.sprite = images[currentIndex]; // Update the UI Image to show the current image
        }
    }

    private void UpdateSideImages()
    {
        // Assuming 6 side images (3 on each side) and their indices are in sequential order around the current image
        int sideImageCount = sideImages.Count / 2; // This should be 3 for 3 images on each side

        for (int i = 0; i < sideImageCount; i++)
        {
            // Update left side images
            int leftIndex = (currentIndex - i - 1 + images.Count) % images.Count;
            sideImages[sideImageCount - 1 - i].sprite = images[leftIndex];

            // Update right side images
            int rightIndex = (currentIndex + i + 1) % images.Count;
            sideImages[sideImageCount + i].sprite = images[rightIndex];
        }
    }
}
