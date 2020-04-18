using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemyAttack;
    private bool attack;
    private void OnMouseOver()
    {
        Globals.p1Stats = false;
        Globals.e1Stats = true;
    }
    private void OnMouseExit()
    {
        Globals.p1Stats = true;
        Globals.e1Stats = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        attack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Globals.e1CanAttack && attack && Globals.menuResult == false)
        {
            GameObject newAttack = Instantiate(enemyAttack, new Vector3(transform.position.x - 1.5f, transform.position.y,
                    transform.position.z), Quaternion.identity, this.transform);
            attack = false;
        }
        if (transform.childCount == 0)
        {
            attack = true;
        }
    }
}
