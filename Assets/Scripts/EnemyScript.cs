using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyScript : MonoBehaviour, IDamage
{

    [Header("EnemyのHP"), SerializeField] public int _enemyHP; //intの既定値は0
    [Header("Enemyの攻撃値"), SerializeField] public int _damageValue;
    [Header("Enemyを倒した時の獲得ポイント"), SerializeField] public int _getPoint;
    Vector2 _startPosition;

    [Header("攻撃オブジェクト")] public GameObject _attackObject;
    [Header("攻撃発射位置")] public Transform _muzzle;
    Transform _player;

    /// <summary> Audio設定 </summary>
	[Header("AudioSourceをアタッチ"), SerializeField] private AudioSource _audio; //コンポーネント
    [Header("BGMファイルから入れる"), SerializeField] private AudioClip _damageSound; //BGM

    void Start()
    {
        _startPosition = this.transform.position; //初期位置を取得
        _player = GameObject.FindGameObjectWithTag("Player").transform;

        if (_player.transform.position.x - _startPosition.x <= 15 && _player.transform.position.x - _startPosition.x >= -15)
        {
            Debug.Log("攻撃");
            GameObject _fire = Instantiate(_attackObject);
            _fire.transform.position = _muzzle.position;
        }
    }

    public abstract void WhenDestroy();

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out IDamage damage))
        {
            damage.ReceiveDamage(_damageValue);
            Debug.Log("damage");
        }

        if (_enemyHP <= 0)
        {
            WhenDestroy();
        }
    }

    public void Attack()
    {
        GameObject _game = Instantiate(_attackObject);
        _game.transform.SetParent(transform);
        _game.transform.position = _attackObject.transform.position;
        _game.SetActive(true);
    }

    public void ReceiveDamage(int damage)
    {
        _enemyHP -= damage;
        Play(_damageSound, 5.0f);
    }

    private void Play(AudioClip audioClip, float volume)
    {
        _audio.clip = audioClip;
        _audio.volume = volume;
        _audio.Play();
    }
}
