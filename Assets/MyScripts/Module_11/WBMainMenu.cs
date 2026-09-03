using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WBMainMenu : MainMenu
{
    public Canvas MainCanvas;
    public Canvas LevelsCanvas;

    public override void Start()
    {
        base.Start();
        LevelsCanvas.gameObject.SetActive(false);
    }

    public override void StartGame()
    {
        LevelsCanvas.gameObject.SetActive(true);
    }

    public void ReturnToMenu()
    {
        LevelsCanvas.gameObject.SetActive(false);
    }

    public void ChangeLevel(int Index)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + Index);
    }
}
