using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] static public float _countdown; //制限時間-クリアまでかかった時間
    [SerializeField] static public int _score; // Project 全体に一つしかないスコア
    [Header("制限時間"), SerializeField] public float _totalTime;

    [Header("Canvasからスコア表示しているTextObjectをアタッチ")]
    [SerializeField] public Text _scoreText;
    [Header("Canvasからカウントダウン表示しているTextObjectをアタッチ")]
    [SerializeField] public Text _countText;

    public Scenemanager sceneManager;
    public bool isGameOver;
    public PlayerController _player;
    public PlayerHP _hp;
    public EnemyScript _boss;
    public int _enemyHP;
    //public GameObject _timeUp;

    /// <summary> DOFade(SceneManager.Script) が実行されている間にずっと実行されないように(1回だけ実行されるように)するフラグ </summary>
    bool _result = false;
    bool _rTrigger = true;


    /// <summary> シーン遷移した後にupdateで遷移の処理をされないようにするためのフラグ </summary>
    //[HideInInspector] public bool isLoad;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerController>();
        _hp = GameObject.Find("Player").GetComponent<PlayerHP>();
        _boss = GameObject.Find("StageBoss").GetComponent<EnemyScript>();
        isGameOver = _player.isGameOver;
        _enemyHP = _boss._enemyHP;
        //_timeUp = GameObject.Find("Timer");

        //スコアの初期化
        _countdown = _totalTime;
        _score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //時間の処理
        _totalTime -= Time.deltaTime;
        _countdown -= _totalTime;

        //Text表示の処理
        _countText.text = _totalTime.ToString();
        _scoreText.text = "Score : " + _score.ToString();

        isGameOver = _player.isGameOver;
        _enemyHP = _boss._enemyHP; // Boss の HP を監視

        if (_result)
        {
            if(_hp._playerHP <= 0)
            {
                _score *= 1;
                Debug.Log(_score);
                Debug.Log(_hp._playerHP);
            }
            else if (_hp._playerHP < 30)
            {
                _score *= 2;
                Debug.Log(_score);
                Debug.Log(_hp._playerHP);
            }
            else if (_hp._playerHP < 50)
            {
                _score *= 3;
                Debug.Log(_score);
                Debug.Log(_hp._playerHP);
            }
            else if (_hp._playerHP < 80)
            {
                _score *= 5;
                Debug.Log(_score);
                Debug.Log(_hp._playerHP);
            }
            else if (80 <= _hp._playerHP && _hp._playerHP <= 100)
            {
                _score *= 10;
                Debug.Log(_score);
                Debug.Log(_hp._playerHP);
            }

            Debug.Log("GameFinish");
            isGameOver = false;
            sceneManager.Fade(false, "ResultScene");
            //isLoad = true;
        }

        if (isGameOver || _enemyHP <= 0 /* || _timeUp.GetComponent<TimeCounter>()._movestop == true */ )
        {
            if (_rTrigger)
            {
                _rTrigger = false;
                _result = true;
            }
            else
            {
                _result = false;
            }
        }
    }
}
