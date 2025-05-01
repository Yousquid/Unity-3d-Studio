using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTalking : MonoBehaviour
{
    public string talkingWords;
    public BoxCollider thisCollider;
    public UIManager uiManager;
    public float floatSpeed = 1f; // Speed of floating
    public float floatHeight = 0.3f; // Height of floating
    private Vector3 startPos;

    private void Start()
    {
        thisCollider = GetComponent<BoxCollider>();
        uiManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<UIManager>();
        startPos = transform.position;
    }
    private void Update()
    {

        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            uiManager.SetTalkingText(talkingWords);
            SoundSystem.instance.PlaySound("npcTalk");
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
