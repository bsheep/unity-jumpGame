using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitlePresenter : MonoBehaviour
{
    public TitleView view;

    bool isCursorToStart;

    // Start is called before the first frame update
    void Start()
    {
        isCursorToStart = true;
        view.setCursorToStart();

        int highscore = 0;
        if (PlayerPrefs.HasKey("Highscore"))
        {
            highscore = PlayerPrefs.GetInt("Highscore");
        }
        view.SetScore(highscore);
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isCursorToStart)
            {
                SceneManager.LoadScene("Stage01");
            }
            else
            {
                // TODO: show tutorial
            }
        }
    }
}
