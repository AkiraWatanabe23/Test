using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFireMovement : MonoBehaviour
{
    [Header("火の生存時間"), SerializeField] float _lifeTime;
    [Header("火の移動速度"), SerializeField] float _speed;
    Transform _playerPos;
    Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _playerPos = GameObject.Find("Player").transform;
        _rb = GetComponent<Rigidbody2D>();

        /// <summary>火はプレイヤーがいる方向に飛んでいく</summary>
        if ((transform.position.x - _playerPos.position.x) > 0f)
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
        _rb.velocity = _rb.velocity.normalized * _speed; //単位ベクトル
    }

    // <summary> 衝突したとき </summary>
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
            _rb.velocity = _rb.velocity.normalized * _speed * -1;
        }
    }
}
