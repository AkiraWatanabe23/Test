using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class FadeIn : MonoBehaviour
{

    [SerializeField] Scenemanager _scene;
    [SerializeField] Image _fadeImage;

    private void OnEnable()
    {
        _scene.StartFadeIn(_fadeImage);
    }
}
