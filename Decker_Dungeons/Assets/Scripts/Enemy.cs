using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
