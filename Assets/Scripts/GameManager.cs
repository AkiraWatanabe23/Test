using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] static public float _countdown; //��������-�N���A�܂ł�����������
    [SerializeField] static public int _score; // Project �S�̂Ɉ�����Ȃ��X�R�A
    [Header("��������"), SerializeField] public float _totalTime;

    [Header("Canvas����X�R�A�\�����Ă���TextObject���A�^�b�`")]
    [SerializeField] public Text _scoreText;
    [Header("Canvas����J�E���g�_�E���\�����Ă���TextObject���A�^�b�`")]
    [SerializeField] public Text _countText;

    public Scenemanager sceneManager;
    public bool isGameOver;
    public PlayerController _player;
    public PlayerHP playerHP;
    public int _playerHP;
    public EnemyScript _boss;
    public int _enemyHP;

    bool _result = false;
    bool _rTrigger = true;


    // <summary> �V�[���J�ڂ������update�őJ�ڂ̏���������Ȃ��悤�ɂ��邽�߂̃t���O </summary>
    //[HideInInspector] public bool isLoad;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerController>();
        playerHP = GameObject.Find("Player").GetComponent<PlayerHP>();
        _boss = GameObject.Find("StageBoss").GetComponent<EnemyScript>();
        isGameOver = _player.isGameOver;
        _playerHP = playerHP._playerHP;
        _enemyHP = _boss._enemyHP;

        //�X�R�A�̏�����
        _countdown = _totalTime;
        _score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //���Ԃ̏���
        _totalTime -= Time.deltaTime;
        _countdown -= _totalTime;

        //Text�\���̏���
        _countText.text = _totalTime.ToString();
        _scoreText.text = "Score : " + _score.ToString();

        isGameOver = _player.isGameOver;
        _enemyHP = _boss._enemyHP; // Boss �� HP ���Ď�

        if (_result)
        {
            if (_playerHP < 20)
            {
                _score *= 2;
                Debug.Log(_score);
            }
            else if (_playerHP < 40)
            {
                _score = 3;
                Debug.Log(_score);
            }
            else if (_playerHP < 70)
            {
                _score *= 5;
                Debug.Log(_score);
            }
            else
            {
                _score *= 10;
                Debug.Log(_score);
            }

            Debug.Log("GameFinish");
            isGameOver = false;
            sceneManager.Fade(false, "ResultScene");
            //isLoad = true;
        }

        if (isGameOver || _enemyHP <= 0)
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
