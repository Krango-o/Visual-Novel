using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveGridButton : MonoBehaviour
{
    [SerializeField]
    private GameObject NoSavePanel;
    [SerializeField]
    private Image ScreenshotImage;
    [SerializeField]
    private Text DateText;
    
    public void SetData(string date, Sprite screenshotSprite = null)
    {
        NoSavePanel.SetActive(false);
        DateText.text = date;
        ScreenshotImage.sprite = screenshotSprite;
    }
}
