using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript: MonoBehaviour, IDamage
{

    [Header("Enemy��HP"), SerializeField] public int _enemyHP = 1;
    [Header("Enemy�̍U���l"), SerializeField] public int _damageValue = 2;
    [Header("Enemy�ۗ̕L�|�C���g"), SerializeField] public int _receivePoint = 2;
    [SerializeField] GameObject _enemyDeath;
    //GameObject gamemanager;

    /// <summary>
	/// Audio�ݒ�
	/// </summary>
	[Header("AudioSource���A�^�b�`"), SerializeField] private AudioSource _audio; //�R���|�[�l���g
    [Header("BGM�t�@�C����������"), SerializeField] private AudioClip _damageSound; //BGM

    void Start()
    {
        //gamemanager = GameObject.Find("GameManager");
        //_enemyHP = 1;
    }

    private void Update()
    {
        if (_enemyHP <= 0)
        {
            //gamemanager.GetComponent<IGetValue>().GetPoint(_receivePoint);
            Instantiate(_enemyDeath);
            Destroy(this.gameObject);
            //GameManager._score += 10;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.TryGetComponent(out IDamage damege))
        {
            damege.ReceiveDamage(2);
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
