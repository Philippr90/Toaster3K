using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Start or quit the game
/// </summary>
public class GameOverScript : MonoBehaviour
{
    private Button[] buttons;
    private Text text;

    void Awake()
    {
        // Get the buttons
        buttons = GetComponentsInChildren<Button>();
        text = GetComponentInChildren<Text>();
        // Disable them
        HideButtons();
        text.gameObject.SetActive(false);
    }

    public void HideButtons()
    {
        foreach (var b in buttons)
        {
            b.gameObject.SetActive(false);
        }
    }

    public void ShowButtons(bool win)
    {
        if(win)
        {
            text.text = "You Win!";
        }
        text.gameObject.SetActive(true);
        foreach (var b in buttons)
        {
            b.gameObject.SetActive(true);
        }
    }

    public void ExitToMenu()
    {
        // Reload the level
        Application.LoadLevel("Menu");
    }

    public void RestartGame()
    {
        // Reload the level
        Application.LoadLevel("Stage1");
    }
}
