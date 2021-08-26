using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageView : MonoBehaviour
{
    public Text scoreText;

    public GameObject mainCamera;

    public GameObject playerPrefab;
    public GameObject applePrefab;
    public GameObject oneWayBlockPrefab;
    public GameObject blockPrefab;
    public GameObject goalPrefab;

    public Player player;

    public void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }

    /// <summary>
    /// ステージ上のアイテムを生成する
    /// </summary>
    /// <param name="chara"></param>
    /// <param name="pos"></param>
    public void SetItem(char chara, Vector3 pos)
    {

        if (chara == '1')
        {
            var obj = Instantiate(playerPrefab, pos, Quaternion.identity);
            player = obj.GetComponent<Player>();
        }
        else if (chara == '2')
        {
            var obj = Instantiate(oneWayBlockPrefab, pos, Quaternion.identity);
            var block = obj.GetComponent<Block>();
            block.setCamera(mainCamera);
        }
        else if (chara == '3')
        {
            Instantiate(blockPrefab, pos, Quaternion.identity);
        }
        else if (chara == '5')
        {
            Instantiate(applePrefab, pos, Quaternion.identity);
        }
        else if (chara == '6')
        {
            Instantiate(goalPrefab, pos, Quaternion.identity);
        }
    }
}
