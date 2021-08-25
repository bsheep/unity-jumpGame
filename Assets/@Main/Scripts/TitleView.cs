using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleView : MonoBehaviour
{
    public GameObject cursor;
    Vector3 cursorPos;

    // Start is called before the first frame update
    void Start()
    {
        cursorPos = cursor.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setCursorToStart()
    {
        cursorPos.y = -200;
        cursor.transform.localPosition = cursorPos;
    }

    public void setCursorToTutorial()
    {
        cursorPos.y = -260;
        cursor.transform.localPosition = cursorPos;
    }
}
