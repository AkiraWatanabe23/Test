using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour, IDamage
{

    [Header("Enemy��HP"), SerializeField] public int _enemyHP; //int�̊���l��0
    [Header("Enemy�̍U���l"), SerializeField] public int _damageValue;
    [Header("Enemy��|�������̊l���|�C���g"), SerializeField] public int _getPoint;
    GameObject _gameManager;

    // <summary> Audio�ݒ� </summary>
	[Header("AudioSource���A�^�b�`"), SerializeField] private AudioSource _audio; //�R���|�[�l���g
    [Header("BGM�t�@�C����������"), SerializeField] private AudioClip _damageSound; //BGM

    void Start()
    {
        _gameManager = GameObject.Find("GameManager");
    }

    private void Update()
    {
        if (_enemyHP <= 0)
        {
            GameManager._score += _getPoint; //enemy ��|������X�R�A���Z
            Destroy(this.gameObject); //Destroy �̏����͍Ō�ɏ���
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out IDamage damage))
        {
            damage.ReceiveDamage(_damageValue);
            Debug.Log("damage");
        }
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
