using UnityEngine;
using UnityEngine.UI;

public class BallSizeController : MonoBehaviour
{
    public Slider sizeSlider; // Reference to the slider in the Inspector
    public Text sizeText;     // Reference to the text element to display size (optional)

    private void Start()
    {
        // Initialize the slider and set the ball's initial size
        sizeSlider.value = 0.5f; // Set an initial value between 0 and 1
        SetBallSize(sizeSlider.value);
    }

    public void OnSliderValueChanged()
    {
        // Called when the slider value changes
        SetBallSize(sizeSlider.value);
        Debug.Log("Slider value: " + sizeSlider.value);
    }

    void SetBallSize(float size)
    {
        // Adjust the ball's size based on the slider value
        Vector3 newScale = Vector3.one * size * 5f; // Adjust 5f based on your desired size range
        transform.localScale = newScale;

        // Update the size text (optional)
        if (sizeText != null)
        {
            sizeText.text = $"Size: {size:F2}";
        }
    }
}
