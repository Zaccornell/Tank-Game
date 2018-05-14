using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{

    public int damage = 20;

    // Use this for initialization
    void Start()
    {
        Destroy(this.gameObject, 4f);
    }

    void OnCollisionEnter(Collision Other)
    {
        if (Other.gameObject.tag == "Player")
        {
            Other.gameObject.GetComponent<TankController>().TakeDamage(damage);
        }
        Destroy(this.gameObject);
    }
}


