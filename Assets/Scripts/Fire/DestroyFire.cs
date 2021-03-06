using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFire : MonoBehaviour
{
    public float _deleteTime;

    // <summary> 衝突したとき </summary>
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Destroy(gameObject, 0.1f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, _deleteTime);
    }
}
