using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PvpButton()
    {
        SceneManager.LoadScene("PVP");
    }

     public void StoryButton()
    {
        SceneManager.LoadScene("ADVENTURE");
    }

    // Update is called once per frame
    public void Exit()
    {
        Application.Quit();
    }
}
