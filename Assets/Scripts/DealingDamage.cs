using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealingDamage : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        // 碰到玩家飛機時，讓玩家處理傷害邏輯
        if (coll.gameObject.tag == "Ship")
        {
            // 玩家飛機的傷害處理已經在Move腳本中實現
            // 這裡只需要銷毀子彈即可
        }

        // 碰到其他可摧毀物體（如敵機、障礙物等）
        else if (coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "Obstacle")
        {
            Destroy(coll.gameObject);
        }

        // 銷毀子彈本身
        Destroy(gameObject);
    }
}

