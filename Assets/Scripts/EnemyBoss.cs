using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : EnemyScript //EnemyScript ‚ğŒp³
{
    public override void WhenDestroy()
    {
        GameManager._score += _getPoint; //enemy ‚ğ“|‚µ‚½‚çƒXƒRƒA‰ÁZ
        Destroy(this.gameObject); //Destroy ‚Ìˆ—‚ÍÅŒã‚É‘‚­
    }
}
