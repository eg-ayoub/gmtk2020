using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField]
    public int hp = 1;

    private bool vulnerable = true;

    public void TakeDamage(int damage)
    {
        if (vulnerable)
        {
            hp -= damage;
        }
    }

    public int GetHP()
    {
        return hp;
    }

    public void SetHP(int iHP)
    {
        hp = iHP;
    }

    public void MakeInvulnerable()
    {
        vulnerable = false;
    }

    public void MakeVulnerable()
    {
        vulnerable = true;
    }
}
