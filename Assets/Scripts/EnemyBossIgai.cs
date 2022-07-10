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
        _time.countdown += _plusTime; //§ŒÀŠÔ‚Ì‰ÁZ
        GameManager._score += _getPoint; //enemy ‚ğ“|‚µ‚½‚çƒXƒRƒA‰ÁZ
        Destroy(this.gameObject); //Destroy ‚Ìˆ—‚ÍÅŒã‚É‘‚­
    }
}
