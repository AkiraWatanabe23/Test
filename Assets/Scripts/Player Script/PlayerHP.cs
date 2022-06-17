using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHP : MonoBehaviour,IDamage
{
    [Header("チェック入れると攻撃を受けない"),SerializeField] public bool _debugMode;
    /// <summary>
    /// HPの値
    /// </summary>
    [SerializeField] public int _playerHP = 100;
    int _maxHP;

    [SerializeField] GameObject HPController;
    [SerializeField] HpController _health;
    Animator _anim;
    
    // Start is called before the first frame update

    public int HP
    {
        set //変更
        {
            _playerHP = Mathf.Clamp(value, 0, _maxHP);
        }
        get //取得
        {
            return _playerHP;
        }
    }

    void Start()
    {
        _maxHP = HPController.GetComponent<HpController>()._maxHP;
        _health = _health.GetComponent<HpController>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _health.UpdateSlider(_playerHP);
        if(_debugMode)
        {
            Invoke("CheatTime", 1f);
            //Debug.Log("無敵時間終了");
        }

        if(_playerHP > _maxHP)
        {
            _playerHP = _maxHP;
        }
    }

    public void ReceiveDamage(int damage)
    {
        if(!_debugMode)
        {
            _playerHP -= damage;
            _anim.SetTrigger("Hurt");
            _debugMode = true;
            Debug.Log("getDamage");
        }
    }

    void CheatTime()
    {
        _debugMode = false;
    }
}
