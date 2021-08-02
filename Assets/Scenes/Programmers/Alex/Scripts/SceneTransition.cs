using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Animator transitionAnim;
    public string sceneName;

    public void Quit()
    {
        StartCoroutine(QuitGame());
    }

    public void Transit()
    {
        StartCoroutine(LoadScene());
    }

    // Will play fade animation and wait 1.5 seconds before loading the specified scene
    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }

    // Will play fade animation and wait 1.5 seconds before quitting the game
    IEnumerator QuitGame()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        Application.Quit();
    }
}
