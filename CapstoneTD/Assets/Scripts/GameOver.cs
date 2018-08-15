using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public string scene = "MainMenu";
    public GameObject ui;

    public void Retry()
    {
        //restart the currently loaded scene. .name returns the name of the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Toggle();
    }

    public void Menu()
    {
       SceneManager.LoadScene(scene);
        Toggle();
    }

    public void Toggle()
    {
        //enable or disable ui, opposite of whatever current state is
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
            //When timeScale is set to zero the game is basically paused 
            //if all your functions are frame rate independent.
            Time.timeScale = 0f;
        else
            //realtime
            Time.timeScale = 1f;
    }
}
