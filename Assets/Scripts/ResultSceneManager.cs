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
            (n) => _minScore = n,// �l�̍X�V
            _score,// �ŏI�I�Ȓl
            3.0f// �A�j���[�V��������
            )
            .OnUpdate(
            () => _scoreText.text = _minScore.ToString("D7")
         ) ;
    }
}