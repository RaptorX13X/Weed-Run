using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioClip gameOverSound;
    [SerializeField] private GameObject victoryScreen;
    [SerializeField] private AudioClip victorySound;

    private void Awake()
    {
        gameOverScreen.SetActive(false);
        victoryScreen.SetActive(false);
    }
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        SoundManager.instance.PlaySound(gameOverSound);
    }
    public void Victory()
    {
        victoryScreen.SetActive(true);
        SoundManager.instance.PlaySound(victorySound);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying= false;
    }
}