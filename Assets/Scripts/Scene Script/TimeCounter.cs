using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    //�J�E���g�_�E��
    [SerializeField] public float countdown;

    //���Ԃ�\������Text�^�̕ϐ�
    [SerializeField]  Text timeText;
    [SerializeField] Text _timeup;
    [SerializeField] Button _toResult;
    public bool _movestop;

    // Update is called once per frame
    void Update()
    {
        countdown = Mathf.Clamp(countdown, 0, countdown);
        //���Ԃ��J�E���g�_�E������
        countdown -= Time.deltaTime;

        //���Ԃ�\������
        timeText.text = countdown.ToString("F0");
        //timeText.text = $"{countdown:F0}"; ������ ����2

        if (countdown <= 0f)
        {
            _toResult.gameObject.SetActive(true);
            _timeup.gameObject.SetActive(true);
            _movestop = true;
        }
    }
}