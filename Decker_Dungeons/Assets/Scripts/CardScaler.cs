using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardScaler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    private Button btn;
    private float posX;
    private float posY;
    private float scaleX;
    private float scaleY;
    void Start()
    {
        btn = GetComponent<Button>();
        posX = transform.position.x;
        posY = transform.position.y;
        scaleX = transform.localScale.x;
        scaleY = transform.localScale.y;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = new Vector3(2.5f, 2.5f, 1f);
        transform.position = new Vector3(posX, 0f, 0f);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.position = new Vector3(posX, posY, 1f);
        transform.localScale = new Vector3(scaleX, scaleY, 1f);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        switch (btn.image.sprite.name)
        {
            case "cards_0":
                Debug.Log("cero");
                break;
            case "cards_1":
                Debug.Log("uno");
                break;
            case "cards_2":
                Globals.e1Life -= 20;
                Debug.Log("dos");
                break;
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        btn.gameObject.SetActive(false);
    }
}