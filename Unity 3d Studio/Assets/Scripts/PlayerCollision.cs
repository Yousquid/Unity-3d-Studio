using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerRigidbodyBasedMove PlayerMovement;
    public PlaceObject PlaceObject;
    public PlayerRespawn PlayerRespawn;
    public float targetTimeScale = 0.1f; // 目标时间流速（50%）
    public float timeScaleDuration = 5f; // 变慢过程的持续时间
    public bool isTimeSlowing;
    private float timeScaleTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        PlayerMovement = GetComponent<PlayerRigidbodyBasedMove>();
        PlaceObject = GameObject.FindWithTag("MainCamera").GetComponent<PlaceObject>();
        PlayerRespawn = GetComponent<PlayerRespawn>();
    }

    
    // Update is called once per frame
    void Update()
    {
        SlowTimeDown();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Soul")
        {
            PlayerMovement.jumpOrdashCount -= 1;
            PlaceObject.soulUsed += 1;
            //StartCoroutine(SlowDownTime());
            isTimeSlowing = true;
        }
        else if (other.gameObject.tag == "Soul_Upgrade")
        {
            PlaceObject.soulMax += 1;
        }
        else if (other.gameObject.tag == "Dead_Area")
        {
            PlayerRespawn.Respawn();
        }
        else if (other.gameObject.tag == "Float_Upgrade")
        {
            PlayerMovement.canfloat = true;
        }
        else if (other.gameObject.tag == "Grappler_Upgrade")
        {
            PlaceObject.graplerMax += 1;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            SoundSystem.instance.PlaySound("Land");
        }
        if (collision.gameObject.tag == "Booster")
        {
            PlayerMovement.canExceedSpeedOnGround = true;
        }
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Booster")
        {
            PlayerMovement.canExceedSpeedOnGround = false;
        }
    }

    private void SlowTimeDown()
    {
        if (isTimeSlowing)
        {
            Time.timeScale = targetTimeScale;
            timeScaleTimer += Time.unscaledDeltaTime;
        }
        if (timeScaleTimer >= timeScaleDuration)
        {
            Time.timeScale = 1;
            isTimeSlowing=false;
            timeScaleTimer = 0f;
        }
    }
}
