using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlus : EnemyScript //EnemyScript を継承
{
    public override void WhenDestroy()
    {
        GameManager._score += _getPoint; //enemy を倒したらスコア加算
        Destroy(this.gameObject); //Destroy の処理は最後に書く
    }
}
