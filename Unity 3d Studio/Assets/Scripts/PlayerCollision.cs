using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerRigidbodyBasedMove PlayerMovement;
    public PlaceObject PlaceObject;
    public PlayerRespawn PlayerRespawn;
    public float targetTimeScale = 0.1f; // Ŀ��ʱ�����٣�50%��
    public float duration = 1.0f; // �������̵ĳ���ʱ��
    // Start is called before the first frame update
    void Start()
    {
        PlayerMovement = GetComponent<PlayerRigidbodyBasedMove>();
        PlaceObject = GameObject.FindWithTag("MainCamera").GetComponent<PlaceObject>();
        PlayerRespawn = GetComponent<PlayerRespawn>();
    }

    IEnumerator SlowDownTime()
    {
        float startScale = Time.timeScale;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.unscaledDeltaTime; // �� unscaledDeltaTime ������ Time.timeScale Ӱ��
            Time.timeScale = 0.6F;
            yield return new WaitForSecondsRealtime(0.01f);
        }

        Time.timeScale = targetTimeScale; // ȷ�����վ�׼�ﵽĿ��ֵ
        StartCoroutine(RestoreTime());

    }

    IEnumerator RestoreTime()
    {
        float startScale = Time.timeScale;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Lerp(startScale, 1.0f, elapsed / duration);
            yield return null;
        }

        Time.timeScale = 1.0f;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Soul")
        {
            PlayerMovement.jumpOrdashCount -= 1;
            PlaceObject.soulUsed += 1;
            StartCoroutine(SlowDownTime());

        }
        if (other.gameObject.tag == "Soul_Upgrade")
        {
            PlaceObject.soulMax += 1;
        }
        if (other.gameObject.tag == "Dead_Area")
        {
            PlayerRespawn.Respawn();
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
}
