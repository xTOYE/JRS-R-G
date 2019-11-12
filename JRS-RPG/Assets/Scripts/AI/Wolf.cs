﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : Enemy
{
    [Space(5), Header("Wolf Stats")]
    public float curStamina;
    public float maxStamina;

    
    public void BiteAttack()
    {
        int critChance = Random.Range(0,21);
        float critDamage = 0;
        if(critChance == 20)
        {
            critDamage = Random.Range(baseDamage / 2, baseDamage * difficulty);
        }
        Debug.Log("Bite");
        player.GetComponent<PlayerHandler>().DamagePlayer(baseDamage*difficulty+ critDamage);
    }
}
