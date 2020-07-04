using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    // Start is called before the first frame update
    public void PvpButton()
    {
        //SceneManager.LoadScene("PVP");
        StartCoroutine(LoadLevel(1));
    }

     public void StoryButton()
    {
        //SceneManager.LoadScene("ADVENTURE");
        StartCoroutine(LoadLevel(2));
    }

    // Update is called once per frame
    public void Exit()
    {
        Application.Quit();
    }

    IEnumerator LoadLevel(int LevelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(LevelIndex);
    }
}
