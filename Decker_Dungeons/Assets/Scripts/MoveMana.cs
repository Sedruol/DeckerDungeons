using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMana : MonoBehaviour
{
    private float values;
    private float newScale;
    private bool changeScale;
    // Start is called before the first frame update
    void Start()
    {
        values = 0f;
        newScale = 72f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            values += Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, 0f, values * 180);
            if (newScale >= 72)
                changeScale = true;
            else if (newScale <= 65)
                changeScale = false;
            if (changeScale)
            {
                changeScale = true;
                newScale -= 0.1f;
                transform.localScale = new Vector3(newScale, newScale, newScale);
            }
            else if (!changeScale)
            {
                newScale += 0.1f;
                transform.localScale = new Vector3(newScale, newScale, newScale);
            }
        }
    }
}
