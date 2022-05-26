using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    bool isGround;//接地しているかどうか、tureなら接地している。falseなら非接地状態を表す。
    // Start is called before the first frame update
    void Start()
    {
        isGround = false;//初期値はfalse
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //isTriggerにチェックが入った、Colliderと接触している場合実行される関数。
    private void OnTriggerStay2D(Collider2D collision)
    {
        //collisionこの変数には接触相手の情報が入る！
        //この場合、接触相手のTagを引っ張ってきて"Ground"か判定する
        //もし、Groundであれば、isGroundをtrueにする！
        if (collision.tag == "Ground")
        {
            isGround = true;
        }
    }

    //この関数はisTriggerにチェックが入ったColliderと離れた時に実行される関数。
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            isGround = false;
        }
    }

    public bool GetIsGround()
    {
        return isGround;
    }
}
