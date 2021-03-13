using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoronaDebila : Effect
{
    public override void UpgradeEffectBasedOnCount(int count)
    {
        LivingEntity temp_player = FindObjectOfType<Player>().GetComponent<LivingEntity>();
        temp_player.maxHealth = 100 + (count * 15);
        temp_player.healthBar.SetMaxHealth(temp_player.maxHealth);
        temp_player.healthBar.SetHealth(temp_player.health);
    }
}
