using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject gameUI;
    public TextMeshProUGUI checkpointTextRemind;
    public TextMeshProUGUI checkpointCheckRemind;
    public bool IsCheckpoint = false;
    public TextMeshProUGUI soulNumberText;
    public TextMeshProUGUI soulMaxText;
    public TextMeshProUGUI grapplerNumberText;
    public TextMeshProUGUI grapplerMaxText;

    public TextMeshProUGUI talkingBarText;
    public Image talkingBarImage;

    public bool IsChecking = false;
    private float checkTimer = 0;
    private float checkTotal = 1f;

    public GameObject startScreenUI;
    public GameObject startCamera;


    private void Start()
    {
        talkingBarImage.gameObject.SetActive(false);
        gameUI.SetActive(false);
    }

    private void Update()
    {
        CheckpointUI();
        CheckTextUI();
    }

    public void SetSoulNumberAndMaxText(int soulAmount, int soulMaxAmount)
    { 
        soulNumberText.text = $"{soulAmount}";
        soulMaxText.text = $"{soulMaxAmount}";
    }

    public void SetGrapplerNumberAndMaxtText(int grapplerNumber, int grapplerMax)
    { 
        grapplerNumberText.text = $"{grapplerNumber}";
        grapplerMaxText.text = $"{grapplerMax}";
    }
    void CheckpointUI()
    {
        if (IsCheckpoint)
        {
            checkpointTextRemind.enabled = true;
        }
        else
        {
            checkpointTextRemind.enabled = false;
        }

        
    }

    public void OnClickStartGame()
    {
        startCamera.SetActive(false);
        startScreenUI.SetActive(false);
        gameUI.SetActive(true);
    }
    public void SetTalkingText(string talkingContext)
    {
        talkingBarImage.gameObject.SetActive(true);
        talkingBarText.text = talkingContext;
    }

    public void CloseTalkingText()
    {
        talkingBarImage.gameObject.SetActive(false);
    }
    void CheckTextUI()
    {
        if (IsChecking)
        { 
            checkpointCheckRemind.enabled = true;
            checkTimer += Time.deltaTime;
        }

        if (checkTimer >= checkTotal)
        {
            checkpointCheckRemind.enabled = false;
            IsChecking = false ;
            checkTimer = 0;
        }
    }
}
