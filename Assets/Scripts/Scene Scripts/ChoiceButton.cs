using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ChoiceButton : MonoBehaviour {

    public string option;
    public DialogueManager box;

    public void SetText( string newText ) {
        this.GetComponentInChildren<TextMeshProUGUI>().text = newText;
    }

    public void SetOption( string newOption ) {
        this.option = newOption;
    }

    public void ParseOption() {
        string command = option.Split(',')[0];
        string commandModifier = option.Split(',')[1];
        box.playerTalking = false;
        if( command == "line" ) {
            box.lineNum = int.Parse(commandModifier)-1;
            box.ShowDialogue();
        } else if( command == "scene" ) {
            SceneManager.LoadScene("Scene" + commandModifier);
        }
    }
}