using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ResultSceneManager : MonoBehaviour
{
    [SerializeField] Text _scoreText;
    GameObject _resultText;

    //このスクリプト内のみで使う
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
        DOTween.To(() => _minScore, (n) => _minScore = n, /*値の更新*/
                         _score, /*最終的な値*/ 3.0f /*アニメーション時間*/ )
                         .OnUpdate(() => _scoreText.text = _minScore.ToString("D4"));
        //表示する桁数をstring型で指定 ... ("D〇")で〇桁表示
        //1行にすると↓のようになる
        // DOTween.To(() => _minScore,(n) => _minScore = n,_score,3.0f).OnUpdate(() => _scoreText.text = _minScore.ToString("D6"));
        //不等号の部分は、「ラムダ式」てのを使ってるらしい... まだ使わないけど、要勉強

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
