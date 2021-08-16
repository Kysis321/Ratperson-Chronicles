using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveSlot: MonoBehaviour
{
    [SerializeField] int buttonNum;
    TextMeshProUGUI myText;

    private void OnEnable()
    {
        SceneEventManager.onSaveSlotTrigger += UpdateText;
    }

    private void OnDisable()
    {
        SceneEventManager.onSaveSlotTrigger -= UpdateText;
    }

    private void Awake()
    {
        myText = this.GetComponentInChildren<TextMeshProUGUI>();
        UpdateText();
    }

    void UpdateText()
    {
        myText.text = buttonNum.ToString() + ": Linenum=" + PlayerPrefs.GetInt("saveLineNum" + buttonNum)
             + ", Scene=" + PlayerPrefs.GetString("saveScene" + buttonNum);
    }
}
