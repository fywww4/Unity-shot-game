using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealingDamage : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        // �I�쪱�a�����ɡA�����a�B�z�ˮ`�޿�
        if (coll.gameObject.tag == "Ship")
        {
            // ���a�������ˮ`�B�z�w�g�bMove�}������{
            // �o�̥u�ݭn�P���l�u�Y�i
        }

        // �I���L�i�R������]�p�ľ��B��ê�����^
        else if (coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "Obstacle")
        {
            Destroy(coll.gameObject);
        }

        // �P���l�u����
        Destroy(gameObject);
    }
}

