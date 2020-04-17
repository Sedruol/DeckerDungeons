using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Button btnHit;
    // Start is called before the first frame update
    void Start()
    {
        btnHit.onClick.AddListener(() => OnHit());
    }

    public void OnHit()
    {
        Globals.e1Life -= 10;
        Debug.Log(Globals.e1Life);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
