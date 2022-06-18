using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpController : MonoBehaviour
{
    [SerializeField] public int _maxHP = 100;
    [HideInInspector] public Slider _hpSlider;
    bool isReturn;
    GameObject _player;
    GameObject _canvas;

    // Start is called before the first frame update
    void Start()
    {
        _player = transform.root.gameObject;
        _canvas = transform.parent.gameObject;
        _hpSlider = GetComponent<Slider>();
        isReturn = _player.GetComponent<PlayerController>().isReturn;
        //�X���C�_�[�ő�l�̐ݒ�E�J�n���ꂽ���������
        _hpSlider.maxValue = _maxHP;
    }

    // Update is called once per frame

    /// <summary> HP���X���C�_�[�ɕ\�������郁�\�b�h </summary>
    public void UpdateSlider(int hp)
    {
        hp = Mathf.Clamp(hp, 0, _maxHP); //(���݂̒l,�ŏ��l,�ő�l)�����Ő������Ă���
                                         // ����̏ꍇ�Ahp�̒l�͈̔͂������Ă���
        _hpSlider.value = hp; //hpSlider�̒l�Ƀv���C���[��hp��������
    }

    void LateUpdate()
    {
        isReturn = _player.GetComponent<PlayerController>().isReturn;

        if (isReturn)
        {
            _canvas.transform.localScale = new Vector3(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
        else
        {
            _canvas.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
    }
}
