using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour, IDamage
{
    [Header("Fireから受けるダメージ"), SerializeField] public int _fireDamage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.TryGetComponent(out IDamage damage))
        {
            damage.ReceiveDamage(5);
            Debug.Log("damage");
        }
    }

    public void ReceiveDamage(int damage)
    {
        throw new System.NotImplementedException();
    }
}
