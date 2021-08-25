using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public TextAsset stageData;

    public GameObject playerPrefab;
    public GameObject applePrefab;
    public GameObject oneWayBlockPrefab;
    public GameObject blockPrefab;
    public GameObject goalPrefab;

    Vector3 cameraSpeed = new Vector3(0, 1f, 0);
    public GameObject mainCamera;
    public GameObject backgroundImage;

    Player player;

    bool isGoal;
    float endPosY;
    bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        var text = stageData.text;
        var lines = text.Split(char.Parse("\n"));
        
        for (int i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            
            for (int j = 0; j < 32; j++)
            {
                var pos = new Vector3(j - 16 + 0.5f, lines.Length - i - 14, 0);
                var chara = line[j];
                if (chara  == '1')
                {
                    var obj = Instantiate(playerPrefab, pos, Quaternion.identity);
                    player = obj.GetComponent<Player>();
                }
                else if (chara == '2')
                {
                    Instantiate(oneWayBlockPrefab, pos, Quaternion.identity);
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
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isGoal)
        {
            if (!isGoal)
            {
                // 終了の初期処理
                endPosY = mainCamera.transform.localPosition.y;
                var playerPosY = player.transform.localPosition.y;
                endPosY += playerPosY - endPosY + 10;
            }
            isGoal = true;
            // 終了位置まで移動
            var pos = mainCamera.transform.localPosition;
            var endPos = pos;
            endPos.y = endPosY;
            mainCamera.transform.localPosition = Vector3.Lerp(pos, endPos, 0.01f);
            
            pos = backgroundImage.transform.localPosition;
            endPos = pos;
            endPos.y = endPosY;
            backgroundImage.transform.localPosition = Vector3.Lerp(pos, endPos, 0.01f);
        }
        else if (isGameOver)
        {

        }
        else
        {
            // カメラと背景を動かす
            var pos = mainCamera.transform.localPosition;
            mainCamera.transform.localPosition = pos + cameraSpeed * Time.deltaTime;
            pos = backgroundImage.transform.localPosition;
            backgroundImage.transform.localPosition = pos + cameraSpeed * Time.deltaTime;

            // ゲームオーバー処理
            var cameraY = mainCamera.transform.localPosition.y;
            var playerY = player.transform.localPosition.y;
            if (cameraY - playerY > 12)
            {
                Destroy(player.gameObject);
                isGameOver = true;
            }
        }
    }
}
