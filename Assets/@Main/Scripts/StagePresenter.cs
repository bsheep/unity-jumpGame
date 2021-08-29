using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx;

public class StagePresenter: MonoBehaviour
{
    public TextAsset stageData;

    StageModel model;
    public StageView view;

    bool isGoal;
    float endPosY;
    bool isGameOver;
    bool canRetry;

    public AudioClip clearClip;
    public AudioClip fallClip;
    public AudioClip hitClip;

    // Start is called before the first frame update
    void Start()
    {
        model = new StageModel();
        view.OnItemCollected = model.ScoreCount;
        model.scoreProperty.Subscribe(view.SetScore).AddTo(this.gameObject);
            

        var text = stageData.text;
        var lines = text.Split(char.Parse("\n"));
        
        for (int i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            
            for (int j = 0; j < 32; j++)
            {
                var pos = new Vector3(j - 16 + 0.5f, lines.Length - i - 14, 0);
                var itemId = line[j];
                view.SetItem(itemId, pos);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (view.player.isGoal)
        {
            if (!isGoal)
            {
                // 終了の初期処理
                endPosY = view.mainCamera.transform.localPosition.y;
                var playerPosY = view.player.transform.localPosition.y;
                endPosY += playerPosY - endPosY + 10;

                // BGMを止めてジングル鳴らす
                var audioSource = FindObjectOfType<AudioSource>();
                audioSource.Stop();
                audioSource.PlayOneShot(clearClip);
            }
            isGoal = true;
            // 終了位置まで移動
            var pos = view.mainCamera.transform.localPosition;
            var endPos = pos;
            endPos.y = endPosY;
            view.mainCamera.transform.localPosition = Vector3.Lerp(pos, endPos, 0.01f);

            // スペース押下でデータを保存してタイトルへ
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SaveData();
                SceneManager.LoadScene("Title");
            }
        }
        else if (isGameOver)
        {
            if(canRetry)
            {
                // スペース押下でデータを保存してタイトルへ
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    SaveData();
                    SceneManager.LoadScene("Title");
                }
            }
        }
        else
        {
            // カメラと背景を動かす
            view.MoveCamera();

            // ゲームオーバー処理
            var cameraY = view.mainCamera.transform.localPosition.y;
            var playerY = view.player.transform.localPosition.y;
            if (cameraY - playerY > 12)
            {
                Destroy(view.player.gameObject);
                isGameOver = true;
                var audioSource = FindObjectOfType<AudioSource>();
                audioSource.Stop();
                audioSource.PlayOneShot(fallClip);
                Invoke("HitEffect", 2f);
            }
        }
    }

    void SaveData()
    {
        int highscore = 0;
        if (PlayerPrefs.HasKey("Highscore"))
        {
            highscore = PlayerPrefs.GetInt("Highscore");
        }
        if (model.Score() > highscore)
        {
            PlayerPrefs.SetInt("Highscore", model.Score());
            PlayerPrefs.Save();
        }
    }

    void HitEffect()
    {
        var audioSource = FindObjectOfType<AudioSource>();
        audioSource.PlayOneShot(hitClip);
        canRetry = true;

        var shaker = view.mainCamera.GetComponent<CameraShaker>();
        shaker.Shake();
    }
}
