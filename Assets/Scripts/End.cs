using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class End : MonoBehaviour
{
    public TMP_Text finalScoreText;
    public void Start()
    {
        finalScoreText.text += "\n" + Globals.TotalScore;
    }
    public void ReturnToMenu() => SceneManager.LoadScene("MainMenu");
}
