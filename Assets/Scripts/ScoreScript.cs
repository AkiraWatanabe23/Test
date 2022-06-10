using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private Text _scoreText = null;
    private int oldScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        _scoreText = GetComponent<Text>();
        if(GameManager.instance != null)
        {
            _scoreText.text = "Score  :  " + GameManager.instance.score;
        }
        else
        {
            Debug.Log("GameManager’u‚«–Y‚ê");
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(oldScore != GameManager.instance.score)
        {
            _scoreText.text = "Score  :  " + GameManager.instance.score;
            oldScore = GameManager.instance.score;
        }
    }
}
