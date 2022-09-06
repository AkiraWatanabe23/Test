using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ResultSceneManager : MonoBehaviour
{
    [SerializeField] Text _scoreText;
    GameObject _resultText;

    //���̃X�N���v�g���݂̂Ŏg���ϐ�
    int _score;
    int _minScore;

    private void Awake()
    {
        _score = GameManager._score;
    }

    // Start is called before the first frame update
    void Start()
    {
        _score = GameManager._score;

        DOTween.To(() => _minScore,
            n => _minScore = n,
            _score, 4.5f)
            .OnUpdate(() => _scoreText.text = _minScore.ToString("D4"));
        //�\�����錅����string�^�Ŏw�� ... ("D�Z")�ŁZ���\��
        //1�s�ɂ���Ɓ��̂悤�ɂȂ�
        // DOTween.To(() => _minScore,(n) => _minScore = n,_score,4.5f).OnUpdate(() => _scoreText.text = _minScore.ToString("D4"));

        _resultText = GameObject.Find("HyoukaText");
        Text resultText = _resultText.GetComponent<Text>();

        if (_score <= 300)
        {
            resultText.text = "Let's try again!";
        }
        else if (_score <= 1000)
        {
            resultText.text = "Good!";
        }
        else if (_score <= 1500)
        {
            resultText.text = "Great!!";
        }
        else if (_score <= 2000)
        {
            resultText.text = "Excellent!!";
        }
        else
        {
            resultText.text = "Congratulations!!";
        }
    }
}
