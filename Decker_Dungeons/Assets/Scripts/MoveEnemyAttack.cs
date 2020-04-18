using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemyAttack : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    [SerializeField] private float velocity;
    private Vector2 velocityVector;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        velocityVector.x = -velocity;
        rigidbody2D.velocity = velocityVector;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
