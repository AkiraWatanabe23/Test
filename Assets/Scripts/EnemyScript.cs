using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript: MonoBehaviour, IDamage
{

    [Header("EnemyのHP"), SerializeField] public int _enemyHP = 1;
    [Header("Enemyの攻撃値"), SerializeField] public int _damageValue = 2;
    [Header("Enemyの保有ポイント"), SerializeField] public int _receivePoint = 2;
    [SerializeField] GameObject _enemyDeath;
    //GameObject gamemanager;

    /// <summary>
	/// Audio設定
	/// </summary>
	[Header("AudioSourceをアタッチ"), SerializeField] private AudioSource _audio; //コンポーネント
    [Header("BGMファイルから入れる"), SerializeField] private AudioClip _damageSound; //BGM

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
