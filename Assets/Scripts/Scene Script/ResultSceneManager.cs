using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ResultSceneManager : MonoBehaviour
{
    [SerializeField] Text _scoreText;
    GameObject _resultText;

    //���̃X�N���v�g���݂̂Ŏg��
    int _score;
    int _minScore;
    //float _countdown;

    private void Awake()
    {
        //_countdown = (int)GameManager._countdown;
        _score = GameManager._score;
        _resultText = GameObject.Find("HyoukaText");
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

        Text resultText = _resultText.GetComponent<Text>();

        if (_score == 0)
        {
            resultText.text = "Let's try again!";
        }
        else if (_score < 1000)
        {
            resultText.text = "Good!";
        }
        else if (_score < 2000)
        {
            resultText.text = "Great!!";
        }
        else
        {
            resultText.text = "Excellent!!";
        }
    }
}
