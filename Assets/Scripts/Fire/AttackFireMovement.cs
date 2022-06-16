using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFireMovement : MonoBehaviour
{
    [Header("�΂̐�������"), SerializeField] float _lifeTime;
    [Header("�΂̈ړ����x"), SerializeField] float _speed;
    PlayerController _player;
    Transform _playerPos;
    Rigidbody2D _rigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerController>();
        _playerPos = GameObject.Find("Player").transform;
        _rigidBody2D = GetComponent<Rigidbody2D>();

        /// <summary>�΂̓v���C���[����������ɔ��ł���</summary>
        if ((transform.position.x - _playerPos.position.x) > 0f)
        {
            _rigidBody2D.velocity = Vector2.left * _speed;
        }
        else
        {
            _rigidBody2D.velocity = Vector2.right * _speed;
        }

        Destroy(this.gameObject, _lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        _rigidBody2D.velocity = _rigidBody2D.velocity.normalized * _speed; //�P�ʃx�N�g��
    }

    // <summary> �Փ˂����Ƃ� </summary>
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Enemy" || col.gameObject.tag == "attack")
        {
            Destroy(gameObject, 0.1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D tri)
    {
        if (tri.gameObject.tag == "Bat")
        {
            Debug.Log("bat");
            _rigidBody2D.velocity = _rigidBody2D.velocity.normalized * _speed * -1;
        }
    }
}
