using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ResultSceneManager : MonoBehaviour
{
    [SerializeField] Text _scoreText;
    GameObject _resultText;

    //このスクリプト内のみで使う変数
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
        //表示する桁数をstring型で指定 ... ("D〇")で〇桁表示
        //1行にすると↓のようになる
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
