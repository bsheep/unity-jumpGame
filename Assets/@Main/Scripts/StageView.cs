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
    public GameObject cherriesPrefab;
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
    /// <param name="itemId"></param>
    /// <param name="pos"></param>
    public void SetItem(char itemId, Vector3 pos)
    {

        if (itemId == '1')
        {
            var obj = Instantiate(playerPrefab, pos, Quaternion.identity);
            player = obj.GetComponent<Player>();
        }
        else if (itemId == '2')
        {
            var obj = Instantiate(oneWayBlockPrefab, pos, Quaternion.identity);
            var block = obj.GetComponent<Block>();
            block.setCamera(mainCamera);
        }
        else if (itemId == '3')
        {
            Instantiate(blockPrefab, pos, Quaternion.identity);
        }
        else if (itemId == '5')
        {
            var obj = Instantiate(applePrefab, pos, Quaternion.identity);
            var fruit = obj.GetComponent<Fruits>();
            fruit.OnItemCollected = OnItemCollected;
        }
        else if (itemId == '6')
        {
            var obj = Instantiate(cherriesPrefab, pos, Quaternion.identity);
            var fruit = obj.GetComponent<Fruits>();
            fruit.OnItemCollected = OnItemCollected;
        }
        else if (itemId == '8')
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
