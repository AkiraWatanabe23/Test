using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAttack : MonoBehaviour
{
    [Header("�U���Ԋu")] public float _interval; //++
    [Header("��������I�u�W�F�N�g"), SerializeField] private GameObject _createObject; //++
    EnemyScript _muzzle;
    [SerializeField] float _rightWidth;
    Transform _muzzlePos;
    private float _lifeTime = 0f;
    private PlayerController _player;
    Transform _playerPos;
    private EnemyScript _enemy;
    public bool _isReturn;


    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerController>();
        _playerPos = GameObject.Find("Player").transform;
        _muzzlePos = transform.GetChild(1);
        //�z��̕ϐ���[�~�����v�f�̃C���f�b�N�X(�Y��)].transform;
        _enemy = GameObject.FindWithTag("Enemy").GetComponent<EnemyScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.x - _playerPos.position.x) > 0f)//���̏ꍇ
        {
            if (_lifeTime > _interval)
            {
                Instantiate(_createObject, _muzzlePos.position, Quaternion.identity);
                _lifeTime = 0f;
            }
        }
        else//�E�̏ꍇ
        {
            if (_lifeTime > _interval)
            {
                Instantiate(_createObject, new Vector3(_muzzlePos.position.x + _rightWidth, _muzzlePos.position.y, 0f), Quaternion.identity);
                _lifeTime = 0f;
            }
        }
        _lifeTime += Time.deltaTime;
    }
}
