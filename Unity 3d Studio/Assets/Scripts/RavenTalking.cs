using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RavenTalking : MonoBehaviour
{
    public string talkingWords;
    public BoxCollider thisCollider;
    public UIManager uiManager;


    private void Start()
    {
        uiManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<UIManager>();
    }
    private void Update()
    {


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            uiManager.SetTalkingText(talkingWords);
            SoundSystem.instance.PlaySound("birdTalk");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            uiManager.CloseTalkingText();
        }
    }
}
