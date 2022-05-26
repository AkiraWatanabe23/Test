using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    bool isGround;//�ڒn���Ă��邩�ǂ����Ature�Ȃ�ڒn���Ă���Bfalse�Ȃ��ڒn��Ԃ�\���B
    // Start is called before the first frame update
    void Start()
    {
        isGround = false;//�����l��false
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //isTrigger�Ƀ`�F�b�N���������ACollider�ƐڐG���Ă���ꍇ���s�����֐��B
    private void OnTriggerStay2D(Collider2D collision)
    {
        //collision���̕ϐ��ɂ͐ڐG����̏�񂪓���I
        //���̏ꍇ�A�ڐG�����Tag�����������Ă���"Ground"�����肷��
        //�����AGround�ł���΁AisGround��true�ɂ���I
        if (collision.tag == "Ground")
        {
            isGround = true;
        }
    }

    //���̊֐���isTrigger�Ƀ`�F�b�N��������Collider�Ɨ��ꂽ���Ɏ��s�����֐��B
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
