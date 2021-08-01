using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;


public class JoshDialogueParser : MonoBehaviour
{
    //we are representing a DialogueLine. Each one of our lines has a few components to it. 
    //Each line has a name, content, pose, position, and a fifth variable which is going to be the options the player will have when given choices.
    struct DialogueLine
    {
        public string name;
        public string content;
        public int pose;
        public string position;
        public string[] options;

        public DialogueLine(string Name, string Content, int Pose, string Position)
        {
            name = Name;
            content = Content;
            pose = Pose;
            position = Position;
            options = new string[0];
        }
    }

    struct EffectsLine {

        public string music;
        public string sfx;

        public EffectsLine(string Music, string Sfx ) {
            music = Music;
            sfx = Sfx;
        }
    }
    // a variable to contain all the different lines of dialogue we will have. We are using a List to hold the DialogueLines.
    List<DialogueLine> lines;
    List<EffectsLine> eLines;

    // Use this for initialization
    bool lineToggle = true;
    //What this function is doing for us is dynamically getting the dialogue file that we saved by looking at the name of the Unity Scene we are in and getting the number from that.
    //It also instantiates the lines List which tells the computer to give us memory to store things in the List because we are about to put things in the List.
    void Start()
    {
        string file = "Assets/Scenes/Programmers/Josh/";
        string sceneNum = EditorApplication.currentScene;
        Debug.Log(sceneNum);
        sceneNum = Regex.Replace(sceneNum, "[^0-9]", "");
        Debug.Log(sceneNum);
        file += sceneNum;
        file += ".txt";
        Debug.Log(file);

        lines = new List<DialogueLine>();
        eLines = new List<EffectsLine>();

        LoadDialogue(file);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LoadDialogue(string filename)
    {
        string line;
        StreamReader r = new StreamReader(filename);

        using (r)
        {
            do
            {
                //this adds 1st line to dialogueline
                line = r.ReadLine();
                if( line != null ) {

                    if( lineToggle ) {
                        string[] lineData = line.Split(';');
                        if( lineData[0] == "Player" ) {
                            DialogueLine lineEntry = new DialogueLine(lineData[0], "", 0, "");
                            lineEntry.options = new string[lineData.Length - 1];
                            for( int i = 1;i < lineData.Length;i++ ) {
                                lineEntry.options[i - 1] = lineData[i];
                            }
                            lines.Add(lineEntry);
                        } else {
                            DialogueLine lineEntry = new DialogueLine(lineData[0], lineData[1], int.Parse(lineData[2]), lineData[3]);
                            lines.Add(lineEntry);
                        }
                        lineToggle = false;
                    }

                    //this adds data from second line to effectsline
                    if( !lineToggle ) {
                        string[] eLineData = line.Split(';');
                        Debug.Log(eLineData);
                        EffectsLine eLineEntry = new EffectsLine(eLineData[0], eLineData[1]);
                        eLines.Add(eLineEntry);
                        lineToggle = true;
                    }
                }
            }
            while (line != null);
            r.Close();
        }
    }

    //The following will output the files information to other areas


    public string GetPosition(int lineNumber)
    {
        if (lineNumber < lines.Count)
        {
            return lines[lineNumber].position;
        }
        return "";
    }

    public string GetName(int lineNumber)
    {
        if (lineNumber < lines.Count)
        {
            return lines[lineNumber].name;
        }
        return "";
    }

    public string GetContent(int lineNumber)
    {
        if (lineNumber < lines.Count)
        {
            return lines[lineNumber].content;
        }
        return "";
    }

    public int GetPose(int lineNumber)
    {
        if (lineNumber < lines.Count)
        {
            return lines[lineNumber].pose;
        }
        return 0;
    }

    public string[] GetOptions(int lineNumber)
    {
        if (lineNumber < lines.Count)
        {
            return lines[lineNumber].options;
        }
        return new string[0];
    }
   
    public string GetMusic( int lineNumber ) {
        if( lineNumber < lines.Count ) {
            return eLines[lineNumber].music;
        }
        return "";
    }

    public string GetSfx( int lineNumber ) {
        if( lineNumber < lines.Count ) {
            return eLines[lineNumber].sfx;
        }
        return "";
    }
}

