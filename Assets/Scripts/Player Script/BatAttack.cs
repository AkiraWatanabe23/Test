using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatAttack : MonoBehaviour
{
    [SerializeField] int _attack = 2;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent(out IDamage damege))
        {
            if (col.gameObject.tag == "Enemy")
            {
                damege.ReceiveDamage(_attack);
                Debug.Log("damage");
            }
        }
    }
}