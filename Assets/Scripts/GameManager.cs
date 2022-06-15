using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public int _enemyHP;
    public EnemyScript _boss;

    // <summary> シーン遷移した後にupdateで遷移の処理をされないようにするためのフラグ </summary>
    //[HideInInspector] public bool isLoad;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerController>();
        _boss = GameObject.Find("StageBoss").GetComponent<EnemyScript>();
        isGameOver = _player.isGameOver;
        _enemyHP = _boss._enemyHP;


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
        _scoreText.text = "Score  :  " + _score.ToString();

        isGameOver = _player.isGameOver;
        _enemyHP = _boss._enemyHP; // Boss の HP を監視

        if (isGameOver || _enemyHP <= 0)
        {
            Debug.Log("GameEnd");
            isGameOver = false;
            sceneManager.Fade(false, "ResultScene");
            //isLoad = true;
        }
    }
}
