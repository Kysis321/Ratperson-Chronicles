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
        DialogueEventManager.onSaveSlotTrigger += UpdateText;
    }

    private void OnDisable()
    {
        DialogueEventManager.onSaveSlotTrigger -= UpdateText;
    }

    private void Awake()
    {
        myText = this.GetComponentInChildren<TextMeshProUGUI>();
        myText.text = buttonNum.ToString() + ": Linenum = " + PlayerPrefs.GetInt("saveLineNum" + buttonNum);
    }

    void UpdateText()
    {
        myText.text = buttonNum.ToString() + ": Linenum = " + PlayerPrefs.GetInt("saveLineNum" + buttonNum);
    }
}
