using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Start or quit the game
/// </summary>
public class GameOverScript : MonoBehaviour
{
    private Button[] buttons;
    private Text[] text;

    void Awake()
    {
        // Get the buttons
        buttons = GetComponentsInChildren<Button>();
        text = GetComponentsInChildren<Text>();
        // Disable them
        HideButtons();
        HideText();
    }

    public void HideButtons()
    {
        foreach (var b in buttons)
        {
            b.gameObject.SetActive(false);
        }
    }
    public void HideText()
    {
        foreach (var t in text)
        {
            t.gameObject.SetActive(false);
        }
    }

    public void ShowButtons(bool win)
    {
        if(win)
        {
            text[0].text = "You Win!";
        }
        foreach (var t in text)
        {
            t.gameObject.SetActive(true);
        }
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
        //Application.LoadLevel("Stage1");
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
