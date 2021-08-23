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
                    Instantiate(playerPrefab, pos, Quaternion.identity);
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
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
