using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using NCMB;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    [SerializeField]
    public GameObject messagePanel;

    [SerializeField]
    public Canvas canvas;

    // ファイルストアのURL
    private const string BASE_URL = "https://mb.api.cloud.nifty.com/2013-09-01/applications/****************/publicFiles/";

    // データストアのクラス名
    private const string CLASS_NAME = "Congratulation";

    private GameObject[] panels;

    private int[] values;

    // パネルのめくれた数
    private int count = 0;

    // パネルのめくれた枚数
    private int dataCount = 0;

    private float timeleft;

    NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>(CLASS_NAME);

    // ２度シーン遷移することを防ぐフラグ
    private bool sceneFlg = true;

    // Use this for initialization
    void Start () {

        // パネルオブジェクトを取得する
        panels = GameObject.FindGameObjectsWithTag("Panel");
        
        // めくる順序を初期化
        values = new int[panels.Length];
        for(int i = 0; i < values.Length; i++)
        {
            values[i] = i;
        }
        Shuffle(values, values.Length);
    }
	
	// Update is called once per frame
	void Update () {

        // デバッグ用にマウスクリックでパネルをめくるようにしています
        if (Input.GetMouseButtonUp(0))
        {
            // パネルをめくる
            StartCoroutine(CurlPannel("Anonymous", "Conguratulation!", "takano.png"));
        }

        // 0.3秒ごとに処理を行う
        timeleft -= Time.deltaTime;
        if (timeleft <= 0.0)
        {
            timeleft = 0.3f;

            // DataStoreからデータを取得する
            FetchDatastore();
        }

        // すべてめくれたかどうか判定する
        // メッセージパネルを取得
        GameObject[] messages = GameObject.FindGameObjectsWithTag("Message");
        if (values.Length == count && messages.Length == 0  && sceneFlg)
        {
            sceneFlg = false;
            // エンディング動画を再生する
            SceneManager.LoadScene("Ending");
        }
    }

    /// <summary>
    /// データストアからメッセージを取得する
    /// </summary>
    private void FetchDatastore()
    {
        //Scoreフィールドの降順でデータを取得
        query.AddAscendingOrder("createDate");
        query.Limit = 1000;

        //データストアでの検索を行う
        query.FindAsync((List<NCMBObject> objList, NCMBException e) => {
            if (e != null)
            {
                //検索失敗時の処理
            }
            else
            {
                if (dataCount == 0 || dataCount != objList.Count)
                {
                    for(int i = dataCount; i < objList.Count; i++)
                    {
                        // mBaaSから取得
                        string _name = objList[i]["name"] as string;
                        string _message = objList[i]["message"] as string;
                        string _photoName = objList[i]["photoName"] as string;

                        // パネルをめくる
                        StartCoroutine(CurlPannel(_name, _message, _photoName));
                    }

                    // データカウント
                    dataCount = objList.Count;
                }
            }
        });
    }


    /// <summary>
    /// パネルをめくる処理
    /// </summary>
    public IEnumerator CurlPannel(string name, string message, string photoName)
    {
        // パネルをめくる
        GameObject gameObject = panels[values[count]];
        Image image = gameObject.GetComponent<Image>();
        image.enabled = false;

        // めくれた枚数を+1する
        count++;

        // パネルを初期化する
        Panel panel = new Panel(messagePanel, name, message);

        // パネルの色をランダムで変更する
        // 今回は1～5の乱数で色を設定しています。
        int colorNum = Random.Range(1, 5);
        switch(colorNum)
        {
            case 1:
                // 緑
                panel.SetPanelColor(ToRGB(0x90bf12), Color.black, Color.black);
                break;

            case 2:
                // 青
                panel.SetPanelColor(ToRGB(0x00a0e8), Color.black, Color.black);
                break;

            case 3:
                // 黄
                panel.SetPanelColor(ToRGB(0xffd600), Color.black, Color.black);
                break;

            case 4:
                // ピンク
                panel.SetPanelColor(ToRGB(0xe9689e), Color.black, Color.black);
                break;

            case 5:
                // オレンジ
                panel.SetPanelColor(ToRGB(0xee7b33), Color.white, Color.white);
                break;
        }

        // wwwクラスのコンストラクタに画像URLを指定
        string url = BASE_URL + photoName;
        WWW www = new WWW(url);

        // 画像ダウンロード完了を待機
        yield return www;

        // パネルにプロフィール画像をセット
        panel.SetPanelImage(www.textureNonReadable, canvas);

    }

    /// <summary>
    /// 乱数を作成する
    /// </summary>
    /// <param name="array"></param>
    /// <param name="size"></param>
    private void Shuffle(int[] array, int size)
    {
        int i = size;
        while (i > 1)
        {
            int j = Random.Range(0, i) % i;
            i--;
            int t = array[i];
            array[i] = array[j];
            array[j] = t;
        }
    }

    /// <summary>
    /// RGBを作成る
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    private static Color ToRGB(uint val)
    {
        var inv = 1f / 255f;
        var c = Color.black;
        c.r = inv * ((val >> 16) & 0xFF);
        c.g = inv * ((val >> 8) & 0xFF);
        c.b = inv * (val & 0xFF);
        c.a = 0.5f;
        return c;
    }

}
