using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;


public class DialogueParser : MonoBehaviour {
    //we are representing a DialogueLine. Each one of our lines has a few components to it. 
    //Each line has a name, content, pose, position, and a fifth variable which is going to be the options the player will have when given choices.
    struct DialogueLine {

        public string name;
        public string content;
        public string[] options;
        public int bg;

        public DialogueLine( string Name, string Content, int Bg ) {
            name = Name;
            content = Content;
            options = new string[0];
            bg = Bg;
        }
    }

    struct EffectsLine {

        public int music;
        public int sfx;

        public EffectsLine( int Music, int Sfx ) {
            music = Music;
            sfx = Sfx;
        }
    }
    // a variable to contain all the different lines of dialogue we will have. We are using a List to hold the DialogueLines.
    List<DialogueLine> lines;
    List<EffectsLine> eLines;

    // Use this for initialization
    //What this function is doing for us is dynamically getting the dialogue file that we saved by looking at the name of the Unity Scene we are in and getting the number from that.
    //It also instantiates the lines List which tells the computer to give us memory to store things in the List because we are about to put things in the List.
    void Awake() {
        
        //this is the folder which contains the text doc
        string file = "Assets/Scenes/A Main FInal Scene/Story";
        string sceneNum = SceneManager.GetActiveScene().name;

        //replaces the word "scene" with nothing
        Debug.Log("scenenum before regex = " + sceneNum);
        sceneNum = Regex.Replace(sceneNum, "[^0-9]", "");
        Debug.Log("scenenum after regex = " + sceneNum);

        file += sceneNum;
        file += ".txt";
        Debug.Log(file);

        lines = new List<DialogueLine>();
        eLines = new List<EffectsLine>();

        LoadDialogue(file);

        Debug.Log("line0 = " + lines[0].name);
        Debug.Log("line1 = " + lines[1].name);
    }

    void LoadDialogue( string filename ) {
        string line;
        StreamReader r = new StreamReader(filename);

        using( r ) {
            do {
                //this adds 1st line to dialogueline
                line = r.ReadLine();
                if( line != null ) {

                    string[] lineData = line.Split(';');
                    if( lineData[0] == "Player" )
                    {
                        DialogueLine lineEntry = new DialogueLine(lineData[0], "", 0);
                        lineEntry.options = new string[lineData.Length - 1];
                        for( int i = 1;i < lineData.Length;i++ )
                        {
                            lineEntry.options[i - 1] = lineData[i];
                        }
                        lines.Add(lineEntry);
                    }else if(lineData[0] == "End") {
                        DialogueLine lineEntry = new DialogueLine(lineData[0], lineData[1], 0);
                        lines.Add(lineEntry);
                    } else {
                        DialogueLine lineEntry = new DialogueLine(lineData[0], lineData[1], int.Parse(lineData[2]));
                        lines.Add(lineEntry);
                    }
                }

                line = r.ReadLine();
                if( line != null ) {

                    //this adds data from second line to effectsline
                    string[] eLineData = line.Split(';');
                    Debug.Log(eLineData);
                    EffectsLine eLineEntry = new EffectsLine(int.Parse(eLineData[0]), int.Parse(eLineData[1]));
                    eLines.Add(eLineEntry);

                }
            }
            while( line != null );
            r.Close();
        }
    }

    //The following will output the files information to other areas

    public string GetName( int lineNumber ) {
        if( lineNumber < lines.Count ) {
            return lines[lineNumber].name;
        }
        return "";
    }

    public string GetContent( int lineNumber ) {
        if( lineNumber < lines.Count ) {
            return lines[lineNumber].content;
        }
        return "";
    }

    public int GetBg( int lineNumber )
    {
        if( lineNumber < lines.Count )
        {
            return lines[lineNumber].bg;
        }
        return 0;
    }

    public string[] GetOptions( int lineNumber ) {
        if( lineNumber < lines.Count ) {
            return lines[lineNumber].options;
        }
        return new string[0];
    }

    public int GetMusic( int lineNumber ) {
        if( lineNumber < lines.Count ) {
            return eLines[lineNumber].music;
        }
        return 0;
    }

    public int GetSfx( int lineNumber ) {
        if( lineNumber < lines.Count ) {
            return eLines[lineNumber].sfx;
        }
        return 0;
    }

    public string GetNextScene( int lineNumber )
    {
        if( lineNumber < lines.Count )
        {
            return lines[lineNumber].content;
        }
        return "Scene1";
    }
}