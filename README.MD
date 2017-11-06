# 『全員参加！メッセージ送信ゲーム』Unityアプリ

<img src="readme-images/app_image_0.PNG" alt="app_image_0" width="700px"><br><br>

## 概要
* 同僚の披露宴の余興で実施した『全員参加！メッセージ送信ゲーム』ゲーム本体のUnityアプリです
* ゲームを動作させるためには本Unityアプリの準備の他、「クライアント側【Webアプリ】」の環境構築が必要です
* 「クライアント側【Webアプリ】」については以下を参照してください
  * https://github.com/natsumo/WeddingProjectWebApp

## 『全員参加！メッセージ送信ゲーム』とは？

<img src="readme-images/game_image.png" alt="game_image" width="750px"><br><br>

* 『全員参加！メッセージ送信ゲーム』は100人超の披露宴参加者全員参加で遊べるお祝いゲームです
* 各自所有しているスマートフォンから指定URLにアクセスすることで誰でも参加できます
* URLにアクセスしたら「名前」と「自撮り画像」を登録します
* ゲームが開始されたら新郎新婦へのお祝いのメッセージを送ります
* お祝いメッセージが登録されると、ゲーム本体に写真付きメッセージが表示されていきます
* お祝いメッセージがいっぱいになると…何かが起こる！？

## 『全員参加！メッセージ送信ゲーム』Unityアプリ事前準備
* ニフクラ mobile backend (以下 mBaaS) の会員登録（無料）
  * http://mb.cloud.nifty.com/

## 動作までの手順
### 1. プロジェクトのダウンロード
* 下記リンクをクリックしてローカルに zip ファイルをダウンロードします
  * https://github.com/syyama/WeddingProjectUnityApp/archive/master.zip
* zip ファイルは解凍しておきます

### 2. mBaaS にアプリを作成
* mBaaS にログインします
  * https://console.mb.cloud.nifty.com/

* アプリの新規作成をします
  * 既に他のアプリを作成済みの場合は、左上の「+新しいアプリ」をクリックします

<img src="readme-images/create_mb_app_1.PNG" alt="create_mb_app_1" width="350px"><br>

* APIキー が発行されます

<img src="readme-images/create_mb_app_2.PNG" alt="create_mb_app_2" width="400px"><br><br>

* 後ほど使用しますので、ここは「OK」をクリックして閉じます
* 閉じるとダッシュボード（管理画面）が表示されます

### 3. プロジェクトファイルの編集
* 先ほどダウンロードし、解凍しておいたフォルダを開きます

<img src="readme-images/dl_files_1.PNG" alt="dl_files_1" width="300px"><br><br>

* `Unity` フォルダをUnityでプロジェクトとして開きます

<img src="readme-images/unity_1.PNG" alt="unity_1" width="220px"><br><br>

* 主なフォルダ構成としては下記の通りです
  * `Image`: プロジェクトで利用する画像を保存します
  * `Movie`: ゲームの前後の動画を保存します
  * `Music`: ゲーム中のBGMを保存します
  * `Scene`: 当プロジェクトのシーンは3つで構成されています
    * `Opening`: ゲームが開始するタイミングで再生される動画のシーンです
    * `Main`: ゲーム本編です
    * `Ending`: ゲームが終了したタイミングで再生される動画のシーンです
  * `Scripts`: 当プロジェクトで利用したスクリプトファイルを保存しています
* 当プロジェクトには `Movie` と `Music` のファイルは含まれていませんので、必要に応じて追加してください

* `Main` シーンの `GameManager` オブジェクトの `NCMB Settings` コンポーネントに mBaaS でアプリを作成した際に生成された APIキー を設定します

<img src="readme-images/unity_2.PNG" alt="unity_2" width="220px"><br><br>

* APIキー は、mBaaS ダッシュボードの右上「アプリ設定」から確認できます

<img src="readme-images/check_mb_api_key.PNG" alt="check_mb_api_key" width="750px"><br><br>

* 次に、`GameManager.cs`の18行目のAPIのURLの `**********` の箇所を編集します

* `YOUR_NCMB_APPLICATION_ID` の部分を mBaaSのアプリIDに書き換えます
* アプリIDは mBaaS ダッシュボードのURLに記載しています
* 例では `**********` としている箇所がアプリIDです

```txt
例）
https://console.mb.cloud.nifty.com/#/applications/**********/
```
### 4. ゲームで使用する背景の設定する

* `Main` シーンの `Backgroud` オブジェクトの `Image` コンポーネントの `Source Image` を設定することで、ゲームで使用する背景を設定することができます
* なお画像は `Sprite` として用意する必要があります

<img src="readme-images/unity_3.PNG" alt="unity_3" width="220px"><br><br>

### 5. ゲームのBGMの設定をする

* `Main` シーンの `MusicManager` オブジェクトの `Audio Source` コンポーネントの `Audio Clip` を設定することで、ゲームで使用するBGMを設定することができます
* なお、ループ再生を行うには `Loop` にチェックを入れておきます

<img src="readme-images/unity_4.PNG" alt="unity_4" width="220px"><br><br>

### 6. オープニング・エンディング動画の設定をする

* `Opening` または `Ending` シーンの `VideoPlayer` オブジェクトの `VideoPlayer` コンポーネントの `Video Clip` を設定することで、オープニング・エンディングそれぞれで再生する動画を設定できます
* 今回は動画再生と同時にBGMを流すので、`Audio Source` の項目に動画再生時に流す音声を設定しておきます

<img src="readme-images/unity_5.PNG" alt="unity_5" width="220px"><br><br>


## 遊び方 ～参加方法～
* URLにアクセスして、名前の入力と写真ファイルの選択をします
* 「Regist」ボタンを押します

<img src="readme-images/app_image_1.PNG" alt="app_image_1" width="250px"><br><br>

* ゲームが開始したら、お祝いメッセージを送ります
* 「おめでとう」ボタン（ベトナム語あり）または、自由記述でメッセージを送ることができます

<img src="readme-images/app_image_2.PNG" alt="app_image_2" width="250px"><br><br>

* データストアにメッセージが登録され、Unity側でメッセージを取得し表示させます

<img src="readme-images/app_image_0.PNG" alt="app_image_0" width="700px"><br><br>


## 解説

* ゲーム本編の動作は `GameManager.cs` ですべて制御しています
* mBaaSのデータストア上に保存されたデータをUnityから呼び出して使用しています

### ポーリング処理の実装
* `Update()` 関数内でデータストアから取得する処理を定期的に実行することでポーリング処理を実装しています
* ここでは0.3秒に1回データストアにアクセスしています

```csharp
  private float timeleft;

	// Update is called once per frame
	void Update () {

        // 0.3秒ごとに処理を行う
        timeleft -= Time.deltaTime;
        if (timeleft <= 0.0)
        {
            timeleft = 0.3f;

            // DataStoreからデータを取得する
            FetchDatastore();
        }
  }
```

### メッセージとファイルストアのURLを取得

* データストアに保存しているデータを取得します
* `query.AddAscendingOrder("createDate");` でデータストアの作成日時の降順で取得するよう設定します
* `query.Limit = 1000;` でクエリを取得する件数を1000件とします（デフォルトは100件）
* `query.FindAsync` 関数を使ってデータストアからデータを取得します
* データの取得に成功すると `if (dataCount == 0 || dataCount != objList.Count)` でデータに追加があるかどうかを判別し、データがない場合は処理を行いません
* さらに、追加のレコードがあった場合にそれぞれ `_name`, `_message`, `_photonName` の変数にセットし、レコード毎にパネルをめくる処理を行っています


```csharp
    // パネルのめくれた枚数
    private int dataCount = 0;

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
```

### データストアから画像を取得する処理
* パネルをめくる処理に関しては、Unity固有の実装ですので説明を割愛します、コードを参照ください
* ファイルストアの基礎となるAPIのURLは先述の通りですが、事前に `アプリID` を設定しておきます
* ファイルストアの自撮り画像はUnity標準の `WWW` クラスを利用することで取得できます
* `www.textureNonReadable` で Texture2Dとし、テクスチャとしてセットします

``` csharp

    private const string BASE_URL = "https://mb.api.cloud.nifty.com/2013-09-01/applications/****************/publicFiles/";

    /// <summary>
    /// パネルをめくる処理
    /// </summary>
    public IEnumerator CurlPannel(string name, string message, string photoName)
    {

        // wwwクラスのコンストラクタに画像URLを指定
        string url = BASE_URL + photoName;
        WWW www = new WWW(url);

        // 画像ダウンロード完了を待機
        yield return www;

        // パネルにプロフィール画像をセット
        panel.SetPanelImage(www.textureNonReadable, canvas);

    }
```

### Webアプリとの連携イメージ
* Webアプリを通して各自所有しているスマートフォンから「名前」と「自撮り画像」を mBaaS に登録します
* お祝いメッセージは同時アクセスが可能なようにスクリプトを通してデータストアに保存します
* Unity側でデータストアの情報をポーリングでデータ件数を取得し、追加があればゲームを進める仕組みです
* 詳細は ゲーム本体【Webアプリ】の解説ページ を参照ください
  *  https://github.com/natsumo/WeddingProjectWebApp

## 参考
* 取り急ぎ作ったゲームなので、一部ソースが酷い箇所があります。何卒ご容赦ください。