using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
        Debug.Log("Created By :  Sugeng-06");
    }
    public void OpenURl(){
        Application.OpenURL("https://github.com/SotongCoding/SUGENG-06-PONG");
    }
}
