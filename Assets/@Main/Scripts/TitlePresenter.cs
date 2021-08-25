using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlePresenter : MonoBehaviour
{
    public TitleView view;

    bool isCursorToStart;

    // Start is called before the first frame update
    void Start()
    {
        isCursorToStart = true;
        view.setCursorToStart();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            isCursorToStart = !isCursorToStart;
            if (isCursorToStart)
            {
                view.setCursorToStart();
            }
            else
            {
                view.setCursorToTutorial();
            }
        }
    }
}
