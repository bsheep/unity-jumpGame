using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StageView : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public GameObject mainCamera;

    public GameObject playerPrefab;
    public GameObject applePrefab;
    public GameObject oneWayBlockPrefab;
    public GameObject blockPrefab;
    public GameObject goalPrefab;

    public Player player;
    Vector3 cameraSpeed = new Vector3(0, 1f, 0);

    public System.Action<int> OnItemCollected;

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
            var obj = Instantiate(applePrefab, pos, Quaternion.identity);
            var fruit = obj.GetComponent<Fruits>();
            fruit.OnItemCollected = OnItemCollected;
        }
        else if (chara == '6')
        {
            Instantiate(goalPrefab, pos, Quaternion.identity);
        }
    }

    public void MoveCamera()
    {
        var pos = mainCamera.transform.localPosition;
        mainCamera.transform.localPosition = pos + cameraSpeed * Time.deltaTime;
    }
}
