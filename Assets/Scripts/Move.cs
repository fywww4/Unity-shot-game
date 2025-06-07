using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 5.0f;
    public static int live = 3;
    public GameObject[] liveGameObject = new GameObject[3];

    // �K�[�L�Įɶ��קK�s�򦩦�
    public float invincibilityTime = 1f;
    private bool isInvincible = false;

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(h, v);
        GetComponent<Rigidbody2D>().velocity = dir.normalized * speed;
        GetComponent<Animator>().SetBool("Flying", v > 0);

        // ��s�R�����
        UpdateLiveDisplay();
    }

    void UpdateLiveDisplay()
    {
        if (live == 2) liveGameObject[0].SetActive(false);
        if (live == 1) liveGameObject[1].SetActive(false);
        if (live <= 0)
        {
            liveGameObject[2].SetActive(false);
            gameObject.SetActive(false);
            // �i�H�b�o�̥[�J�C�������޿�
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �קאּ�˴��ľ��l�u�μľ�
        if ((collision.gameObject.CompareTag("EnemyBullet") ||
             collision.gameObject.CompareTag("Enemy")) && !isInvincible)
        {
            TakeDamage();

            // �p�G�O�l�u�A�P���l�u
            if (collision.gameObject.CompareTag("EnemyBullet"))
            {
                Destroy(collision.gameObject);
            }
        }
    }

    // �]�i�H��Trigger�˴��]�p�G�l�u�OTrigger�^
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("EnemyBullet") ||
             other.gameObject.CompareTag("Enemy")) && !isInvincible)
        {
            TakeDamage();

            if (other.gameObject.CompareTag("EnemyBullet"))
            {
                Destroy(other.gameObject);
            }
        }
    }

    void TakeDamage()
    {
        live--;
        StartCoroutine(InvincibilityCoroutine());
        Debug.Log("����ˮ`! �Ѿl�ͩR: " + live);
    }

    // �u�ȵL�Įɶ�
    IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;

        // �i��G�{�{�ĪG
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            for (int i = 0; i < 5; i++)
            {
                sr.color = new Color(1, 1, 1, 0.5f);
                yield return new WaitForSeconds(0.1f);
                sr.color = new Color(1, 1, 1, 1f);
                yield return new WaitForSeconds(0.1f);
            }
        }

        isInvincible = false;
    }
}