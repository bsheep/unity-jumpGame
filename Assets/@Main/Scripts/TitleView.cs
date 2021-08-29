using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class TitleView : MonoBehaviour
{
    public GameObject cursor;
    Vector3 cursorPos;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        cursorPos = cursor.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void setCursorToStart()
    {
        cursorPos.y = -200;
        cursor.transform.DOLocalMove(cursorPos, 0.5f).SetEase(Ease.OutQuart);
    }

    public void setCursorToTutorial()
    {
        cursorPos.y = -260;
        cursor.transform.DOLocalMove(cursorPos, 0.5f).SetEase(Ease.OutQuart);
    }
}
