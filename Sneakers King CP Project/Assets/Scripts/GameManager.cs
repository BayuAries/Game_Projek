using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject panelPause;
    public GameObject p1win;
    public GameObject p2win;
    public GameObject deads;
    public Animator transition;
    public float transitionTime = 1f;

    public void PauseControl()
    {
        if (Time.timeScale == 1)
        {
            panelPause.SetActive(true);
            Time.timeScale = 0;

        }
        else
        {
            Time.timeScale = 1;
            panelPause.SetActive(false);
        }

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        //Application.LoadLevel(0);
        StartCoroutine(Loadlevel(0));
        Time.timeScale = 1;
        panelPause.SetActive(false);
        
    }

    public void Win1()
    {
        p1win.SetActive(true);
    }

    public void Win2()
    {
        p2win.SetActive(true);
    }

    public void dead()
    {
        deads.SetActive(true);
    }

    IEnumerator Loadlevel(int LevelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(LevelIndex);
    }
}
