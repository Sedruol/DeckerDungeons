using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardsEffects : MonoBehaviour
{
    /*public Button card1;
    public Button card2;
    public Button card3;*/
    private Button card;
    // Start is called before the first frame update
    void Start()
    {
        card = GetComponent<Button>();
        /*card1.onClick.AddListener(() => EffectCard());
        card2.onClick.AddListener(() => EffectCard());
        card3.onClick.AddListener(() => EffectCard());*/
    }

    public void EffectCard()
    {
        switch (card.image.sprite.name)
        {
            case "cards_0": Debug.Log("cero");
                break;
            case "cards_1": Debug.Log("uno");
                break;
            case "cards_2": Debug.Log("dos");
                break;
        }
        /*if (card1.image.sprite.name == "cards_0")
            Debug.Log("ash");*/
    }
}