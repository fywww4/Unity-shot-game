using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 5.0f;
    public static int live = 3;
    public GameObject[] liveGameObject = new GameObject[3];

    // 添加無敵時間避免連續扣血
    public float invincibilityTime = 1f;
    private bool isInvincible = false;

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(h, v);
        GetComponent<Rigidbody2D>().velocity = dir.normalized * speed;
        GetComponent<Animator>().SetBool("Flying", v > 0);

        // 更新愛心顯示
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
            // 可以在這裡加入遊戲結束邏輯
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 修改為檢測敵機子彈或敵機
        if ((collision.gameObject.CompareTag("EnemyBullet") ||
             collision.gameObject.CompareTag("Enemy")) && !isInvincible)
        {
            TakeDamage();

            // 如果是子彈，銷毀子彈
            if (collision.gameObject.CompareTag("EnemyBullet"))
            {
                Destroy(collision.gameObject);
            }
        }
    }

    // 也可以用Trigger檢測（如果子彈是Trigger）
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
        Debug.Log("受到傷害! 剩餘生命: " + live);
    }

    // 短暫無敵時間
    IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;

        // 可選：閃爍效果
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