using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public enum LoadOrigin 
{
    NewGame,
    LevelSelect
}

public static class Globals
{
    public static int LevelScore { get; set; }
    public static int TotalScore { get; set; }
    public static int CurrentLevel { get; set; }
    public static int PickupsLeft { get; set; }
    public static Vector3 LastCheckPoint = new Vector3(0, 3, 0);
    // public static float totalTime;
    public static LoadOrigin LevelLoadedWith;

    public static void LoadNewGame() 
    {
        LevelScore   = 0;
        TotalScore   = 0;
        CurrentLevel = 1;
        // totalTime    = 0;
        LevelLoadedWith = LoadOrigin.NewGame;
        SceneManager.LoadScene("Level1");
    }
    
    public static void LoadSelectLevel(string level) 
    {
        LevelScore   = 0;
        TotalScore   = 0;
        // totalTime    = 0;
        LevelLoadedWith = LoadOrigin.LevelSelect;
        SceneManager.LoadScene(level);
    }

    public static void LoadNextScreen()
    {
        Globals.LastCheckPoint = new Vector3(0, 3, 0);
        switch(Globals.LevelLoadedWith)
        {
            case LoadOrigin.NewGame:
                CurrentLevel = CurrentLevel > 0 ? CurrentLevel : 1;
                TotalScore += Mathf.Abs(LevelScore);
                LevelScore = 0;
                CurrentLevel++;
                
                string nextScene;
                if      (CurrentLevel  < 4) nextScene = "Level" + CurrentLevel;
                else if (CurrentLevel == 4) nextScene = "JavaOd1oDukeAppears";
                else    nextScene = "End";
                
                SceneManager.LoadScene(nextScene);
                break;
            
            default:
                SceneManager.LoadScene("MainMenu");
                break;
        }
    }

    public static void UpdateScoreText(TMP_Text scoreText, TMP_Text pickupsText) 
    {
        string totalStr = LevelLoadedWith == LoadOrigin.NewGame 
                           ? "<color=#AAA>TOTAL: " + TotalScore 
                           : "";
        scoreText.text =
            "<mspace=0.9em>\n" + 
            "<color=#FFAA00>LEVEL: " + LevelScore + "\n" +
            totalStr;

        string pickupsStr = PickupsLeft > 0
                            ? "<color=#AAA>PICKUPS LEFT: " + PickupsLeft
                            : "";
        pickupsText.text = 
            "<mspace=0.9em>\n" +
            pickupsStr;
    }

    // public static void UpdateTimer(float time, TMP_Text timeText)
    // {
    //     totalTime += time;
    //     var span = TimeSpan.FromSeconds(totalTime);
    //     // timeText.text = string.Format("TIME: {0}:{1}:{2}", span.Minutes, span.Seconds, span.Milliseconds);
    //     timeText.text = span.ToString("h'h 'm'm 's's'");
    // }
}

