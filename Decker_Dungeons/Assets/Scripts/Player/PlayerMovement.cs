using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //private Vector3 newPosition;
    [SerializeField] private float speed;
    private Vector3 posMouse;
    private Rigidbody2D rb;
    private bool canMove;
    // Start is called before the first frame update
    void Start()
    {
        //newPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        posMouse = transform.position;
        canMove = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Main Camera")
            canMove = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Main Camera")
            canMove = false;
    }
    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            canMove = false;
            posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //newPosition = new Vector3(posMouse.x, newPosition.y, newPosition.z);
            if (posMouse.x < 7f && posMouse.x > -7f)
            {
                if (posMouse.x > transform.position.x)
                {
                    transform.localScale = new Vector3(1f, 1f, 1f);
                    //rb.velocity = new Vector2(5f, 0f);
                    Debug.Log("derecha");
                }
                else if (posMouse.x < transform.position.x)
                {
                    transform.localScale = new Vector3(-1f, 1f, 1f);
                    //rb.velocity = new Vector2(-5f, 0f);
                    Debug.Log("izquierda");
                }
                canMove = true;
            }
            //rb.MovePosition(new Vector2(posMouse.x, transform.position.y));
            //transform.position = new Vector3(posMouse.x, transform.position.y, transform.position.z);
        }
        if (canMove)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y),
                new Vector2(posMouse.x, transform.position.y), step);
        }
        /*if (transform.position.x >= posMouse.x || transform.position.x <= posMouse.x)
        {
            rb.velocity = new Vector2(0f, 0f);
        }*/
    }
}
