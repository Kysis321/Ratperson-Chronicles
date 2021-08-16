using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneInit : MonoBehaviour
{
    //should be set to 0 on scene end
    public int lineNum = 0;
    public bool saveLoad = false;

    private static SceneInit instance;

    private void Awake()
    {
        // If no Player ever existed, we are it.
        if( instance == null )
            instance = this;
        // If one already exist, it's because it came from another level.
        else if( instance != this )
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void loadGame(string newScene, int newNum)
    {
        lineNum = newNum;
        saveLoad = true;
        SceneManager.LoadScene(newScene);
    }
}
