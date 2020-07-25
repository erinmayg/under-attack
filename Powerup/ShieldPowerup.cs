using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerup : Powerup {
    [SerializeField] Sprite costume;
    public override void ActivatePower(PowerupManager player) {
        
        player.SetCostume(costume);
        player.ActivateShield();
    }
}
