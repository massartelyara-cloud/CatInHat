using UnityEngine;
using UnityEngine.UI;

public class InstructionsPopup : MonoBehaviour
{
    public GameObject popupPanel;

    void Start()
    {
        // Show the popup when the game begins
        popupPanel.SetActive(true);
        // Freeze the game until dismissed
        Time.timeScale = 0f;
    }

    public void ClosePopup()
    {
        popupPanel.SetActive(false);
        // Unfreeze the game
        Time.timeScale = 1f;
    }
}