using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class GameStart : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void closewindow();
    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        
        Application.Quit();
        closewindow();
        Application.OpenURL("https://github.com/vicksonrodrigues/Return-of-Forgotten-King");
    }
}