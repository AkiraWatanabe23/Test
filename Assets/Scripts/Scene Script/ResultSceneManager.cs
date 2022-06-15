using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ResultSceneManager : MonoBehaviour
{

    [SerializeField] Text _scoreText;

    //���̃X�N���v�g���݂̂Ŏg��
    int _score;
    int _minScore;
    float _countdown;

    private void Awake()
    {
        //_count = GameObject.Find("Timer").GetComponent<TimeCounter>();
        //countdown = (int)Math.Ceiling(_count.countdown); //float��int �ɕύX����
        _countdown = (int)GameManager._countdown;
        _score = GameManager._score;
    }

    // Start is called before the first frame update
    void Start()
    {
        _score = GameManager._score;

        //_scoreText.text = _score.ToString();
        DOTween.To(() => _minScore, (n) => _minScore = n, /*�l�̍X�V*/
                         _score, /*�ŏI�I�Ȓl*/ 3.0f /*�A�j���[�V��������*/ )
                         .OnUpdate(() => _scoreText.text = _minScore.ToString("D4"));
                                                //�\�����錅����string�^�Ŏw�� ... ("D�Z")�ŁZ���\��
        //1�s�ɂ���Ɓ��̂悤�ɂȂ�
        // DOTween.To(() => _minScore,(n) => _minScore = n,_score,3.0f).OnUpdate(() => _scoreText.text = _minScore.ToString("D6"));
        //�s�����̕����́A�u�����_���v�Ă̂��g���Ă�炵��... �܂��g��Ȃ����ǁA�v�׋�
    }
}
