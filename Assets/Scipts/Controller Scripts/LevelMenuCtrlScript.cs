using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenuCtrlScript : MonoBehaviour {

	public void Level()
    {
        Application.LoadLevel(name: "PlayGame");
    }

    public void BackMenu()
    {
        Application.LoadLevel(name: "MainMenu");
    }
}
