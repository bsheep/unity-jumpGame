using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StagePresenter: MonoBehaviour
{
    public TextAsset stageData;


    Vector3 cameraSpeed = new Vector3(0, 1f, 0);
    public GameObject mainCamera;
    public GameObject backgroundImage;

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
        var text = stageData.text;
        var lines = text.Split(char.Parse("\n"));
        
        for (int i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            
            for (int j = 0; j < 32; j++)
            {
                var pos = new Vector3(j - 16 + 0.5f, lines.Length - i - 14, 0);
                var chara = line[j];
                view.SetItem(chara, pos);
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
                endPosY = mainCamera.transform.localPosition.y;
                var playerPosY = view.player.transform.localPosition.y;
                endPosY += playerPosY - endPosY + 10;

                // BGMを止めてジングル鳴らす
                var audioSource = FindObjectOfType<AudioSource>();
                audioSource.Stop();
                audioSource.PlayOneShot(clearClip);
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
            if(canRetry)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    SceneManager.LoadScene("Title");
                }
            }
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

    void HitEffect()
    {
        var audioSource = FindObjectOfType<AudioSource>();
        audioSource.PlayOneShot(hitClip);
        canRetry = true;

        var shaker = mainCamera.GetComponent<CameraShaker>();
        shaker.Shake();
    }
}
