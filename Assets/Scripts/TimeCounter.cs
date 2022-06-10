using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    //カウントダウン
    [SerializeField] float countdown = 1000;

    //時間を表示するText型の変数
    [SerializeField] Text timeText;
    [SerializeField] Text _timeup;
    public bool _movestop;

    // Update is called once per frame
    void Update()
    {
        countdown = Mathf.Clamp(countdown, 0, countdown);
        //時間をカウントダウンする
        countdown -= Time.deltaTime;

        //時間を表示する
        timeText.text = countdown.ToString("F0");

        //countdownが0以下になったとき
        if (countdown <= 0)
        {
            _timeup.gameObject.SetActive(true);
            _movestop = true;
        }
    }
}