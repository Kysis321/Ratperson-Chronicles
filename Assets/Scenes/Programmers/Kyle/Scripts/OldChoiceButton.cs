using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class OldChoiceButton : MonoBehaviour
{
    /* //*B
    public string option;
    public OldDialogueManager box;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetText(string newText)
    {
        this.GetComponentInChildren<TextMeshProUGUI>().text = newText;
    }

    public void SetOption(string newOption)
    {
        this.option = newOption;
    }

    public void ParseOption()
    {
        string command = option.Split(',')[0];
        string commandModifier = option.Split(',')[1];
        box.playerTalking = false;
        if (command == "line")
        {
            box.lineNum = int.Parse(commandModifier);
            box.ShowDialogue();
        }
        else if (command == "scene")
        {
            //*B
            //Application.LoadLevel("Scene" + commandModifier);
        }
    }
    */
}