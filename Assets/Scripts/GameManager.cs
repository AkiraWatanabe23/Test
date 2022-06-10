using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour //ゲームマネージャー
{
    public static GameManager instance = null;
    public int score;
    public Scenemanager sceneManager;
    public bool isGameOver;
    public PlayerController _player;
    // <summary>シーン遷移した後にupdateで遷移の処理をされないようにするためのフラグ</summary>
    public bool isLoad;
    string scene;

    private void Awake() //インスタンス化された瞬間に呼ばれるメソッド
                         //(Startメソッドより前に処理される)
    {
        if (instance == null) //シングルトン(?) ... 1つしか存在しないもの
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject); //シーン切り替え時に破壊されないようにする
        }

        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        sceneManager = GameObject.Find("SceneManager").GetComponent<Scenemanager>();
        _player = GameObject.Find("Player").GetComponent<PlayerController>();
        //scene = SceneManager.GetActiveScene().name;
        isGameOver = _player.isGameOver;
        if (SceneManager.GetActiveScene().name == "TitleScene")
        {
            isLoad = false;
            Debug.Log("isLoad");
            score = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLoad)
        {
            isGameOver = _player.isGameOver;
            
            if (isGameOver)
            {
                sceneManager.Fade(false, "ResultScene");
                isLoad = true;
                isGameOver = false;
                Debug.Log("isGameOver = false");
            }
        }
    }
}
