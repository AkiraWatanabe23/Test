using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFire : MonoBehaviour
{
    public float _deleteTime;

    // <summary> è’ìÀÇµÇΩÇ∆Ç´ </summary>
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
