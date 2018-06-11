using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public interface IToolTip
{
    string getToolTipMessage();
};

public class Tooltip : MonoBehaviour
{
    GameObject toolTip;
    Image image;
    Text text;
    Canvas canvas;
    Vector2 baseSize;
    IToolTip currentHelper;

    public static Tooltip instance;

    // Use this for initialization
    void Start()
    {
        toolTip = transform.GetChild(0).gameObject;
        image = toolTip.GetComponent<Image>();
        text = GetComponentInChildren<Text>();
        canvas = GetComponent<Canvas>();
        instance = this;

        baseSize = text.rectTransform.rect.size;

        Hide();
    }

    void Update()
    {
        // do this for health bars counting down etc, where the tooltip changes
        if (image.enabled && currentHelper != null)
        {
            SetText(currentHelper.getToolTipMessage());
        }
    }

    public void Show(Vector3 position, string msg, IToolTip helper)
    {
        currentHelper = helper;

        SetText(msg);

        toolTip.SetActive(true);
        toolTip.transform.position = position;

        // position it based on quadrant of the screen
        RectTransform rect = image.rectTransform;
        rect.pivot = new Vector2(position.x < canvas.pixelRect.width / 2 ? 0 : 1, position.y < canvas.pixelRect.height / 2 ? 0 : 1);
    }

    void SetText(string msg)
    {
        // trim whitespace at the end
        while (msg.EndsWith("\n") || msg.EndsWith(" "))
            msg = msg.Remove(msg.Length - 1);

        if (text.text != msg)
        {
            text.text = msg;

            // size it to hold the text we've given it
            TextGenerator textGen = new TextGenerator();
            TextGenerationSettings generationSettings = text.GetGenerationSettings(baseSize);
            float width = textGen.GetPreferredWidth(msg, generationSettings);
            float height = textGen.GetPreferredHeight(msg, generationSettings);

            image.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width + 20);
            image.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height + 20);
            text.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
            text.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
        }
    }

    public void Hide()
    {
        toolTip.SetActive(false);
    }
}

