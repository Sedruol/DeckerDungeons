using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsSelected : MonoBehaviour
{
    [SerializeField] private GameObject cards;
    private int cant;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Contador()
    {
        int temp = 0;
        for (int i = 0; i < cards.transform.childCount; i++)
        {
            if (cards.transform.GetChild(i).GetComponent<ScaleCard>().selected)
            {
                temp++;
            }
        }
        if (temp > cant)
            cant = temp;
        Debug.Log(cant);
    }
    // Update is called once per frame
    void Update()
    {
    }
}
