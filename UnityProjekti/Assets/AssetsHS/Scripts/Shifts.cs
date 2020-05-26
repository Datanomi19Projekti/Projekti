using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Shifts : MonoBehaviour
{
    [SerializeField] private ScoreManager scoremanager;
    [SerializeField] private GameObject targetObject;
    [SerializeField] private string targetMessage;

    public void PlayRestart()
    {
        SceneManager.LoadScene("Level1");
    }
        public void PlayKehitys()
    {
        SceneManager.LoadScene("Kehitys");
    }
        public void PlayMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Debug.Log("lopeta");
        Application.Quit();
    }
}
