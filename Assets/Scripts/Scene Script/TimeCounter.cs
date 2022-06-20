using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    //カウントダウン
    [SerializeField] public float countdown;

    //時間を表示するText型の変数
    [SerializeField]  Text timeText;
    [SerializeField] Text _timeup;
    [SerializeField] Button _toResult;
    public bool _movestop;

    // Update is called once per frame
    void Update()
    {
        countdown = Mathf.Clamp(countdown, 0, countdown);
        //時間をカウントダウンする
        countdown -= Time.deltaTime;

        //時間を表示する
        timeText.text = countdown.ToString("F0");
        //timeText.text = $"{countdown:F0}"; 書き方 その2

        if (countdown <= 0f)
        {
            _toResult.gameObject.SetActive(true);
            _timeup.gameObject.SetActive(true);
            _movestop = true;
        }
    }
}