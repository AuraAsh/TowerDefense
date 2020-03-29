using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadScene(string Level1)
    {
        SceneManager.LoadSceneAsync(Level1);
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("You Left");
    }
}
