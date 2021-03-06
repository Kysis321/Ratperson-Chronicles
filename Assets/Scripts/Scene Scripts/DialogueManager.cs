using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;


public class DialogueManager : MonoBehaviour
{
    DialogueParser parser;
    SceneInit initialiser;
    public GameObject background;

    [SerializeField] string dialogue, characterName, newScene;
    [SerializeField] int currentMusic, sfx, bg;
    public int lineNum;
    string[] options;
    public bool playerTalking;
    List<Button> buttons = new List<Button>();

    public TextMeshProUGUI dialogueBox;
    public TextMeshProUGUI nameBox;
    public GameObject choiceBox;

    public AudioPlayer musicPlayer;
    public AudioPlayer sfxPlayer;

    // Use this for initialization
    void Start()
    {
        dialogue = "";
        characterName = "";
        playerTalking = false;
        parser = GameObject.Find("DialogueParser").GetComponent<DialogueParser>();
        initialiser = GameObject.Find("SceneInit").GetComponent<SceneInit>();
        if( initialiser.saveLoad )
        {
            lineNum = initialiser.lineNum;
            initialiser.saveLoad = false;
        } else
        {
            lineNum = 0;
        }
        ShowDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown("d") && playerTalking == false )
        {

            lineNum++;
            ShowDialogue();

        }

        if( Input.GetKeyDown("a"))
        {
            if (lineNum > 0)
            {
                lineNum--;
                ShowDialogue();
            }
            else
            {
                //*BB
                // Load the previous scene, and the last line of that scene
            }

        }

        UpdateUI();
    }

    public void ShowDialogue()
    {
        ParseLine();
    }

    void UpdateUI()
    {
        if (!playerTalking)
        {
            ClearButtons();
        }
        dialogueBox.text = dialogue;
        nameBox.text = characterName;
    }

    void ClearButtons()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            print("Clearing buttons");
            Button b = buttons[i];
            buttons.Remove(b);
            Destroy(b.gameObject);
        }
    }

    void ParseLine()
    {
        if( parser.GetName(lineNum) == "End" )
        {
            newScene = parser.GetNextScene(lineNum);
            initialiser.loadGame(newScene, 0);
        } 
        else if (parser.GetName(lineNum) != "Player")
        {
            playerTalking = false;
            characterName = parser.GetName(lineNum);
            dialogue = parser.GetContent(lineNum);
            bg = parser.GetBg(lineNum);
            DisplayImages();

            currentMusic = parser.GetMusic(lineNum);
            sfx = parser.GetSfx(lineNum);
            ChangeMusic();
            PlaySfx();
        }
        else
        {
            playerTalking = true;
            characterName = "";
            dialogue = "";
            options = parser.GetOptions(lineNum);
            CreateButtons();
            ChangeMusic();
            PlaySfx();
        }
    }

    void CreateButtons()
    {
        for (int i = 0; i < options.Length; i++)
        {
            GameObject button = (GameObject)Instantiate(choiceBox);
            Button b = button.GetComponent<Button>();
            ChoiceButton cb = button.GetComponent<ChoiceButton>();
            cb.SetText(options[i].Split(':')[0]);
            cb.option = options[i].Split(':')[1];
            cb.box = this;
            b.transform.SetParent(this.transform);
            b.transform.localPosition = new Vector3(0, -25 + (i * 120));
            b.transform.localScale = new Vector3(1, 1, 1);
            buttons.Add(b);
        }
    }

    void DisplayImages()
    {
        if( bg != 0 )
        {
            background.GetComponent<Image>().sprite = background.GetComponent<BackgroundManager>().sprites[bg - 1];
        }
    }

    void ChangeMusic() {
        if( currentMusic == 66 )
        {
            musicPlayer.StopSong();
        } 
        else if( currentMusic != 0 ) {
            //*B debug.log("playing currentMusic=" + currentMusic);
            musicPlayer.ChangeSong(currentMusic-1);
        }
    }

    void PlaySfx() {
        if( sfx != 0 ) {
            //*B debug.log("playing sfx=" + sfx);
            sfxPlayer.ChangeSong(sfx-1);
        }
    }

    public void SetLineNum(int newLineNum)
    {
        lineNum = newLineNum;
    }
    public int GetLineNum()
    {
        return lineNum;
    }
}