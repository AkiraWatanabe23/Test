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
}
