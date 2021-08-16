using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSystem: MonoBehaviour
{
    DialogueManager diagMang;
    int saveLineNum;
    string saveScene;

    SceneInit initialiser;

    [SerializeField] GameObject SaveMenu;
    bool isSave;

    // Start is called before the first frame update
    void Start()
    {
        diagMang = GameObject.Find("Manager").GetComponent<DialogueManager>();
        initialiser = GameObject.Find("SceneInit").GetComponent<SceneInit>();
    }

    public void SetIsSave(bool type )
    {
        isSave = type;
        SceneEventManager.TriggerSaveSlot();
    }
    
    public void ToggleSaveMenu()
    {
        if( SaveMenu.activeSelf == false )
        {
            SaveMenu.SetActive(true);
        } else
        {
            SaveMenu.SetActive(false);
        }
    }

    public void ButtonClick(int buttonNum)
    {
        if( isSave )
        {
            saveLineNum = diagMang.GetLineNum();
            PlayerPrefs.SetInt("saveLineNum" + buttonNum, saveLineNum);
            PlayerPrefs.SetString("saveScene" + buttonNum, SceneManager.GetActiveScene().name);
            SceneEventManager.TriggerSaveSlot();
        } else
        {
            saveLineNum = PlayerPrefs.GetInt("saveLineNum" + buttonNum);
            saveScene = PlayerPrefs.GetString("saveScene" + buttonNum);
            initialiser.loadGame(saveScene, saveLineNum);
        }
    }
}
