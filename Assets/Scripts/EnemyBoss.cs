using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : EnemyScript //EnemyScript ���p��
{
    public override void WhenDestroy()
    {
        GameManager._score += _getPoint; //enemy ��|������X�R�A���Z
        Destroy(this.gameObject); //Destroy �̏����͍Ō�ɏ���
    }
}
