using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{

    public void LoadScene(string sceneName) //Select Scene On Click
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame() //Quit Game
    {
        Application.Quit();
        Debug.Log("the game has exited");
    }


}
