using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour //�Q�[���}�l�[�W���[
{
    public static GameManager instance = null;
    public int score;
    public Scenemanager sceneManager;
    public bool isGameOver;
    public PlayerController _player;
    // <summary>�V�[���J�ڂ������update�őJ�ڂ̏���������Ȃ��悤�ɂ��邽�߂̃t���O</summary>
    public bool isLoad;
    string scene;

    private void Awake() //�C���X�^���X�����ꂽ�u�ԂɌĂ΂�郁�\�b�h
                         //(Start���\�b�h���O�ɏ��������)
    {
        if (instance == null) //�V���O���g��(?) ... 1�������݂��Ȃ�����
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject); //�V�[���؂�ւ����ɔj�󂳂�Ȃ��悤�ɂ���
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
