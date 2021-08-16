using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public Texture2D cursorClicked;
    public Texture2D cursor;

    //private CursorControls controls;

    private Camera mainCamera;

    private void Awake()
    {
        //ChangeCursor(cursor);
        //controls = new CursorControls();
        mainCamera = Camera.main;
    }

    /*private void ChangeCursor(Texture2D cursorType)
    {
        Cursor.SetCursor(cursorType, Vector2.zero, CursorMode.Auto);
    }

    private void OnEnable() //function is called when left click is press
    {
        controls.Enable();
    }

    private void OnDisable() //function is called when left click is release
    {
        controls.Disable();

    }

    private void Start()
    {
        controls.Mouse.LeftClick.started += _ => StartedClick();
        controls.Mouse.LeftClick.performed += _ => EndedClick();
    }

    private void StartedClick()
    {
        ChangeCursor(cursorClicked);
        ////*B debug.log("Started Click");
    }

    private void EndedClick()
    {
        ////*B debug.log("Ended Click");
        DetectObject();
        ChangeCursor(cursor);
    }*/

    public void zDetectObject(string _tag)
    {

        //*B
        /*
        //for 3D objects
        Ray ray = mainCamera.ScreenPointToRay(controls.Mouse.Position.ReadValue<Vector2>());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                if (hit.collider.tag == "Enemy") //if the raycast collided with an object with the tag "Enemy"
                {
                    hit.collider.gameObject.GetComponent<EnemyScript>().onClickEnemy(); //find the object script and execute this function
                }
                //*B debug.log("3D Hit: " + hit.collider.tag);
            }
        }
        //for 2D objects
        RaycastHit2D hits2D = Physics2D.GetRayIntersection(ray);
        if (hits2D.collider != null)
        {
            if (hits2D.collider.tag == "Enemy") //if the raycast collided with an object with the tag "Enemy"
            {
                hits2D.collider.gameObject.GetComponent<EnemyScript>().onClickEnemy(); //find the object script and execute this function
            }
            //*B debug.log("2D Hit: " + hits2D.collider.tag);
        }
        */

    }

}
