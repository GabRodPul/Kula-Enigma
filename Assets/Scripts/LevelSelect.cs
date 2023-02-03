using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    public void LoadSelectLevel(string levelName) => Globals.LoadSelectLevel(levelName);
}
