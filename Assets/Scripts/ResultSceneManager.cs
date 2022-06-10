using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ResultSceneManager : MonoBehaviour
{

    [SerializeField] Text _scoreText;
     GameObject gameManager;
    int _score = 10;
    int _minScore = 0;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager");
        _score = gameManager.GetComponent<GameManager>().score;
    }

    // Start is called before the first frame update
    void Start()
    {

        //_scoreText.text = _score.ToString();
        DOTween.To(
            () => _minScore,
            (n) => _minScore = n,// 値の更新
            _score,// 最終的な値
            3.0f// アニメーション時間
            )
            .OnUpdate(
            () => _scoreText.text = _minScore.ToString("D7")
         ) ;
    }
}
