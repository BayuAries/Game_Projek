using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("Player") || col.gameObject.CompareTag("Player"))
        {
            print("Naik Level");
            StartCoroutine(LoadLevel(3));
        }
    }

    IEnumerator LoadLevel(int LevelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(LevelIndex);
    }
}
