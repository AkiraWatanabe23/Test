using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyScript : MonoBehaviour, IDamage
{

    [Header("Enemy��HP"), SerializeField] public int _enemyHP; //int�̊���l��0
    [Header("Enemy�̍U���l"), SerializeField] public int _damageValue;
    [Header("Enemy��|�������̊l���|�C���g"), SerializeField] public int _getPoint;
    Vector2 _startPosition;

    [Header("�U���I�u�W�F�N�g")] public GameObject _attackObject;
    [Header("�U�����ˈʒu")] public Transform _muzzle;
    Transform _player;

    /// <summary> Audio�ݒ� </summary>
	[Header("AudioSource���A�^�b�`"), SerializeField] private AudioSource _audio; //�R���|�[�l���g
    [Header("BGM�t�@�C����������"), SerializeField] private AudioClip _damageSound; //BGM

    void Start()
    {
        _startPosition = this.transform.position; //�����ʒu���擾
        _player = GameObject.FindGameObjectWithTag("Player").transform;

        if (_player.transform.position.x - _startPosition.x <= 15 && _player.transform.position.x - _startPosition.x >= -15)
        {
            Debug.Log("�U��");
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
