using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour, IDamage
{
    [Header("Fire‚©‚çó‚¯‚éƒ_ƒ[ƒW"), SerializeField] public int _fireDamage;

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.TryGetComponent(out IDamage damage))
        {
            damage.ReceiveDamage(_fireDamage);
            Debug.Log("damage");
        }
    }

    public void ReceiveDamage(int damage)
    {

    }
}
