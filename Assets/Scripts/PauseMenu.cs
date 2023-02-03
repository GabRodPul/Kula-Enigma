using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu, player;
    public TMP_Text scoreText, pickupsText;
    // public TMP_Text timeText;

    public void OnPause()
    {
        if (pauseMenu.activeSelf) {
            Resume();
            return;
        };
        pauseMenu.SetActive(true);
        scoreText.gameObject.SetActive(false);
        pickupsText.gameObject.SetActive(false);
        // timeText.gameObject.SetActive(false);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        scoreText.gameObject.SetActive(true);
        pickupsText.gameObject.SetActive(true);
        // timeText.gameObject.SetActive(true);
        Time.timeScale = 1f;
    }

    public void LastCheckPoint()
    {
        var rb = player.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        player.transform.eulerAngles = Vector3.zero;
        player.transform.position = Globals.LastCheckPoint;
        Resume();
    }

    public void MainMenu() => SceneManager.LoadScene("MainMenu");
}
