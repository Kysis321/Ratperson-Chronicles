using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;


public class JoshDialogueManager : MonoBehaviour
{
    JoshDialogueParser parser;
    public GameObject background;

    [SerializeField] string dialogue, characterName;
    [SerializeField] int currentMusic, sfx, bg;
    public int lineNum;
    int pose;
    string position;
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
        pose = 0;
        position = "L";
        playerTalking = false;
        parser = GameObject.Find("DialogueParser").GetComponent<JoshDialogueParser>();
        lineNum = 0;

        ShowDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && playerTalking == false)
        {

            lineNum++;
            ShowDialogue();

        }

        if( Input.GetMouseButtonDown(1) && lineNum-1 > -1 )
        {

            lineNum--;
            ShowDialogue();

        }

        UpdateUI();
    }

    public void ShowDialogue()
    {
        ResetImages();
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
        if (parser.GetName(lineNum) != "Player")
        {
            playerTalking = false;
            characterName = parser.GetName(lineNum);
            dialogue = parser.GetContent(lineNum);
            pose = parser.GetPose(lineNum);
            position = parser.GetPosition(lineNum);
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
            pose = 0;
            position = "";
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
            JoshChoiceButton cb = button.GetComponent<JoshChoiceButton>();
            cb.SetText(options[i].Split(':')[0]);
            cb.option = options[i].Split(':')[1];
            cb.box = this;
            b.transform.SetParent(this.transform);
            b.transform.localPosition = new Vector3(0, -25 + (i * 120));
            b.transform.localScale = new Vector3(1, 1, 1);
            buttons.Add(b);
        }
    }

    void ResetImages()
    {
        if (characterName != "")
        {
            GameObject character = GameObject.Find(characterName);
            SpriteRenderer currSprite = character.GetComponent<SpriteRenderer>();
            currSprite.sprite = null;
        }
    }

    void DisplayImages()
    {
        if (characterName != "")
        {
            GameObject character = GameObject.Find(characterName);

            SetSpritePositions(character);

            SpriteRenderer currSprite = character.GetComponent<SpriteRenderer>();
            currSprite.sprite = character.GetComponent<JoshCharacter>().characterPoses[pose];
            currSprite.enabled = false;
        }

        background.GetComponent<Image>().sprite = background.GetComponent<BackgroundManager>().sprites[bg];
    }


    void SetSpritePositions(GameObject spriteObj)
    {
        if (position == "L")
        {
            spriteObj.transform.position = new Vector3(-6, 0);
        }
        else if (position == "R")
        {
            spriteObj.transform.position = new Vector3(6, 0);
        }
        spriteObj.transform.position = new Vector3(spriteObj.transform.position.x, spriteObj.transform.position.y, 0);
    }

    void ChangeMusic() {
        if( currentMusic != 0 ) {
            currentMusic -= 1;
            Debug.Log("playing currentMusic=" + currentMusic);
            musicPlayer.ChangeSong(currentMusic);
        }
    }

    void PlaySfx() {
        if( sfx != 0 ) {
            sfx -= 1;
            Debug.Log("playing sfx=" + sfx);
            sfxPlayer.ChangeSong(sfx);
        }
    }
}