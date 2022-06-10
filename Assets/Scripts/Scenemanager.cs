using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class Scenemanager : MonoBehaviour
{
    [Header("イメージを貼り付ける")]
    [SerializeField] Image _fadeImage;

    public void StartFadeOut(string scene)//フェードアウト関数
    {
        _fadeImage.gameObject.SetActive(true);
        //徐々に暗くする→Sceneを遷移する
        this._fadeImage.DOFade(duration: 1f, endValue: 1f).OnComplete(() => SceneManager.LoadScene(scene));
        //ImageのColorは透明に設定
        GameManager.instance.score = 0; //TitleSceneに戻った時にScoreをリセットする
        Debug.Log("Score Reset");
    }
    public void StartFadeIn()//フェードイン関数
    {
        //徐々に明るくする→フェードに使っていたパネルを非表示にする
        this._fadeImage.DOFade(endValue: 0f, duration: 1f).OnComplete(() => _fadeImage.gameObject.SetActive(false));
        //ImageのColorは真っ黒に設定
    }

    public void Fade(bool type, string scene)//呼び出す関数
    {
        //フェードイン関数と同じ処理
        if (type)// type = true:Scene遷移した後に呼び出す処理。string sceneの部分にnullと記述する必要がある。
        {
            this._fadeImage.DOFade(endValue: 0f, duration: 1f).OnComplete(() => _fadeImage.gameObject.SetActive(false));
            //ImageのColorは真っ黒に設定
        }
        //フェードアウト関数と同じ処理
        else//type = false:panelをactiveにした後Scene遷移するからstring sceneの記述が必要
        {
            _fadeImage.gameObject.SetActive(true);
            this._fadeImage.DOFade(duration: 1f, endValue: 1f).OnComplete(() => SceneManager.LoadScene(scene));
            //ImageのColorは透明に設定
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
