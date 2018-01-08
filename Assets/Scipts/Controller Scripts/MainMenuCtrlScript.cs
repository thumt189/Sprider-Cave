using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCtrlScript : MonoBehaviour
{

    public void PlayGame()
    {
        Application.LoadLevel(name: "PlayGame");
    }

}
