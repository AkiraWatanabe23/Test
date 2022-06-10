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
    //string scene;

    private void Awake() //�C���X�^���X�����ꂽ�u�ԂɌĂ΂�郁�\�b�h
                         //(Start���\�b�h���O�ɏ��������)
    {
        if (instance == null) //�V���O���g��(?) ... 1�������݂��Ȃ�����
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject); //�V�[���؂�ւ����ɔj�󂳂�Ȃ��悤�ɂ���
        }

        //else
        //{
        //    Destroy(this.gameObject);
        //}
    }

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerController>();
        //scene = SceneManager.GetActiveScene().name;
        isGameOver = _player.isGameOver;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLoad && SceneManager.GetActiveScene().name != "ResultScene")
        {
            isGameOver = _player.isGameOver;
            
            if (isGameOver) //���� isGameOver=true �Ȃ��
            {
                sceneManager.Fade(false, "ResultScene");
                isGameOver = false;
                isLoad = true;
                Debug.Log("isGameOver = false");
            }
           
        }

        if (SceneManager.GetActiveScene().name == "TitleScene")
        {
            isLoad = false;
            Debug.Log("isLoad");
            score = 0;
        }
    }
}
