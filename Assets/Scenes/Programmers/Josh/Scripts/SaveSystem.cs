using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem: MonoBehaviour
{
    [SerializeField] JoshDialogueManager diagMang;
    int saveLineNum;

    [SerializeField] GameObject SaveMenu;

    bool isSave;

    // Start is called before the first frame update
    void Start()
    {
        diagMang = GameObject.Find("Manager").GetComponent<JoshDialogueManager>();
    }

    public void SetIsSave(bool type )
    {
        isSave = type;
        DialogueEventManager.TriggerSaveSlot();
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
        } else
        {
            saveLineNum = PlayerPrefs.GetInt("saveLineNum" + buttonNum);
            diagMang.SetLineNum(saveLineNum);
            diagMang.ShowDialogue();
        }
        DialogueEventManager.TriggerSaveSlot();
    }
}
