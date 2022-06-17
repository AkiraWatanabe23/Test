using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHP : MonoBehaviour,IDamage
{
    [Header("�`�F�b�N�����ƍU�����󂯂Ȃ�"),SerializeField] public bool _debugMode;
    /// <summary>
    /// HP�̒l
    /// </summary>
    [SerializeField] public int _playerHP = 100;
    int _maxHP;

    [SerializeField] GameObject HPController;
    [SerializeField] HpController _health;
    Animator _anim;
    
    // Start is called before the first frame update

    public int HP
    {
        set //�ύX
        {
            _playerHP = Mathf.Clamp(value, 0, _maxHP);
        }
        get //�擾
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
            //Debug.Log("���G���ԏI��");
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
