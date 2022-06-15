using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAttack : MonoBehaviour
{
    [Header("�X�s�[�h")] public float _speed;
    [Header("�ő�ړ��͈�")] public float _maxDistance;
    [Header("�o�ߌ�ɔj��")] public float _lifeTime;
    [Header("�U���Ԋu")] public float _interval; //++
    [Header("��������I�u�W�F�N�g"), SerializeField] private GameObject _createObject; //++
    EnemyScript _muzzle;
    private PlayerController _player;
    private EnemyScript _enemy;
    public bool _isReturn;


    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerController>();
        _muzzle = GameObject.Find("enemy_attack_muzzle").GetComponent<EnemyScript>();
        _enemy = GameObject.FindWithTag("Enemy").GetComponent<EnemyScript>();
        Rigidbody2D _rb = GetComponent<Rigidbody2D>();

        if(!_player.isReturn)
        {
            _rb.velocity = Vector2.left * _speed;
        }
        else
        {
            _rb.velocity = Vector2.right * _speed;
        }

        Destroy(this.gameObject, _lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (_lifeTime <= _interval)
        {
            GameObject fire = Instantiate(_createObject);
            fire.transform.position = _muzzle.transform.position;
            _interval = 0;
        }
    }
}
