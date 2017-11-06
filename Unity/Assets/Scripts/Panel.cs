using UnityEngine;
using UnityEngine.UI;

public class Panel
{
    private GameObject panel;
    private Text[] texts;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="panelObject"></param>
    /// <param name="name"></param>
    /// <param name="message"></param>
    public Panel(GameObject panelObject, string name, string message)
    {
        panel = GameObject.Instantiate(panelObject);
        texts = panel.GetComponentsInChildren<Text>();

        texts[0].text = name;
        texts[1].text = message;
    }

    /// <summary>
    /// パネルに色をセット
    /// </summary>
    /// <param name="panelColor"></param>
    /// <param name="nameColor"></param>
    /// <param name="messageColor"></param>
    public void SetPanelColor(Color panelColor, Color nameColor, Color messageColor)
    {
        Image panelImage = panel.GetComponent<Image>();

        panelImage.color = panelColor;
        texts[0].color = nameColor;
        texts[1].color = messageColor;
    }


    /// <summary>
    /// パネルに画像をセット
    /// </summary>
    /// <param name="image"></param>
    /// <param name="canvas"></param>
    public void SetPanelImage(Texture2D image, Canvas canvas)
    {
        // 画像を設定
        Image[] images = panel.GetComponentsInChildren<Image>();
        images[2].material.mainTexture = image;

        // キャンバスにパネルをセット
        panel.transform.SetParent(canvas.transform, false);
    }
}