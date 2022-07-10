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
        _time.countdown += _plusTime; //�������Ԃ̉��Z
        GameManager._score += _getPoint; //enemy ��|������X�R�A���Z
        Destroy(this.gameObject); //Destroy �̏����͍Ō�ɏ���
    }
}
