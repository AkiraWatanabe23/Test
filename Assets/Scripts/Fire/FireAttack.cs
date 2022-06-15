using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAttack : MonoBehaviour
{
    [Header("スピード")] public float _speed;
    [Header("最大移動範囲")] public float _maxDistance;
    [Header("経過後に破壊")] public float _lifeTime;
    [Header("攻撃間隔")] public float _interval; //++
    [Header("生成するオブジェクト"), SerializeField] private GameObject _createObject; //++
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
