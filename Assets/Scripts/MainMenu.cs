using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void StartNewGame() => Globals.LoadNewGame();
    public void QuitGame() {
        Debug.Log("XDDDD");
        Application.Quit();
    }
}
