using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int enemyLayer;
    // Start is called before the first frame update
    void Start()
    {
        enemyLayer = LayerMask.NameToLayer("Enemy");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == enemyLayer)
        {
            Globals.p1Life -= 10f;
            Globals.p1CanAttack = true;
            Globals.e1CanAttack = false;
            Destroy(collision.gameObject);
        }
    }
}
