using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTime : MonoBehaviour
{
    public float _deleteTime;

    private void OnEnable()
    {
        if (_deleteTime >= 1.5)
        {
            gameObject.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject, _deleteTime); //gameObject(¡‰ñ‚Ìê‡"+10")‚ª_deleteTime•bŒo‰ß‚µ‚½‚çAÁ‚¦‚é
    }
}
