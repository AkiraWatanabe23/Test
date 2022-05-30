using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    [SerializeField] CheckGround checkground_Script;
    Rigidbody2D _rb;

    float jump_height;
    float jump_power;
    int jump_count = 0;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && jump_count < 1)
        {
            if (checkground_Script.GetIsGround())
            {
                _rb.velocity = new Vector3(0, jump_height, 0);
                //rigidbody2D.AddForce(Vector2.up * jump_power, ForceMode2D.Impulse);
                jump_count++;
            }
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            jump_count = 0;
        }
    }
}
