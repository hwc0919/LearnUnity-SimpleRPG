using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    static public DialogueUI Instance { get; set; }

    private TextMeshProUGUI nameText;
    private TextMeshProUGUI contentText;
    private Button continueButton;

    private List<string> contentsBuffer;
    private int contentIndex;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        nameText = transform.Find("NameBg/NameText").GetComponent<TextMeshProUGUI>();
        contentText = transform.Find("ContentText").GetComponent<TextMeshProUGUI>();
        continueButton = transform.Find("ContinueButton").GetComponent<Button>();
        continueButton.onClick.AddListener(this.OnContinue);
        Hide();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Show(string name, string[] contents)
    {
        if (contents == null || contents.Length == 0)
        {
            return;
        }
        nameText.text = name;
        contentsBuffer = new List<string>(contents);
        contentIndex = 0;
        contentText.text = contentsBuffer[contentIndex];

        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void OnContinue()
    {
        ++contentIndex;
        if (contentsBuffer.Count <= contentIndex)
        {
            contentIndex = 0;
            contentsBuffer = null;
            Hide();
        }
        else
        {
            contentText.text = contentsBuffer[contentIndex];
        }
    }
}
