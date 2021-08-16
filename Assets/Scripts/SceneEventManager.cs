using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEventManager : MonoBehaviour
{
    /*
    public static DialogueEventManager current;

    private void Awake()
    {
        if( current == null )
            current = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }*/

    
    public delegate void SaveAction(); //declare a delegate called saveaction
    public static event SaveAction onSaveSlotTrigger; //declare a static event delegate of type SaveAction which is called onSaveSlotTrigger
    
    //the following is a public static method for calling the onSaveSlotTrigger event
    static public void TriggerSaveSlot()
    {
        if (onSaveSlotTrigger != null )
        {
            onSaveSlotTrigger();
        }
    }
}
