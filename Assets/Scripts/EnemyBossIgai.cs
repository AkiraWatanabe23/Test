using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossIgai : EnemyScript
{
    [SerializeField] public TimeCounter _time;
    [SerializeField] public float _plusTime;

    private void Start()
    {
        _time = GameObject.Find("Timer").GetComponent<TimeCounter>();
    }

    public override void WhenDestroy()
    {
        _time.countdown += _plusTime; //制限時間の加算
        GameManager._score += _getPoint; //enemy を倒したらスコア加算
        Destroy(this.gameObject); //Destroy の処理は最後に書く
    }
}
