using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveSlot: MonoBehaviour
{
    [SerializeField] int buttonNum;
    TextMeshProUGUI myText;

    private void Awake()
    {
        myText = this.GetComponentInChildren<TextMeshProUGUI>();
        myText.text = buttonNum.ToString() + ": Linenum = " + PlayerPrefs.GetInt("saveLineNum" + buttonNum);
    }
    
    private void Update()
    {
        if( Input.GetKeyDown("w") )
        {
            myText.text = buttonNum.ToString() + ": Linenum = " + PlayerPrefs.GetInt("saveLineNum"+buttonNum);
        }
    }
}
