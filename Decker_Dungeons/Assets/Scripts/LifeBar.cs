using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeBar : MonoBehaviour
{
    public Image fullLifeBar;//100 de vida = 480 width, -10 width = -5 pos x
    public Image lifeBar;//empieza -216 pos x | 48 width
    public Image Board;//100 de vida = 500 width, empieza -216 pos x | 68 width
    //empieza con 10 de vida = 48 width y -216 pos x, aumenta 2 width = 1 pos x, aumenta en 48 de width y 24 de pos 
    [SerializeField] private GameObject Portal;
    [SerializeField] private GameObject Enemy;
    [SerializeField] private GameObject Cards;
    [SerializeField] private GameObject Hit;
    private float maxLife;
    private void Awake()
    {
        Enemy.SetActive(true);
        Cards.SetActive(true);
        Hit.SetActive(true);
        Portal.SetActive(false);
        //Globals.p1Life = Globals.p1MaxLife;//max life in globals, changue to main menu
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            Globals.eTLife = Globals.e1MaxLife;
            Globals.eTMaxLife = Globals.eTLife;
            Globals.eTStrength = Globals.e1Strength;
            Globals.eTIntelligence = Globals.e1Intelligence;
            Globals.eTBloodlust = Globals.e1Bloodlust;
            Globals.eTInitiative = Globals.e1Initiative;
            Globals.eTAgility = Globals.e1Agility;
        }
        else if (SceneManager.GetActiveScene().name == "Level 2")
        {
            Globals.eTLife = Globals.e2MaxLife;
            Globals.eTMaxLife = Globals.eTLife;
            Globals.eTStrength = Globals.e2Strength;
            Globals.eTIntelligence = Globals.e2Intelligence;
            Globals.eTBloodlust = Globals.e2Bloodlust;
            Globals.eTInitiative = Globals.e2Initiative;
            Globals.eTAgility = Globals.e2Agility;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "Player Life")
        {
            if (Globals.p1Life > 10f)
            {
                fullLifeBar.rectTransform.sizeDelta = new Vector2(48 + 4.8f * (Globals.p1Life - 10), fullLifeBar.rectTransform.sizeDelta.y);
                fullLifeBar.rectTransform.localPosition = new Vector2(-216f + 2.4f * (Globals.p1Life - 10),
                    fullLifeBar.rectTransform.localPosition.y);
                lifeBar.rectTransform.sizeDelta = new Vector2(48 + 4.8f * (Globals.p1Life - 10), lifeBar.rectTransform.sizeDelta.y);
                lifeBar.rectTransform.localPosition = new Vector2(-216f + 2.4f * (Globals.p1Life - 10), lifeBar.rectTransform.localPosition.y);
                Board.rectTransform.sizeDelta = new Vector2(68 + 4.8f * (Globals.p1Life - 10), Board.rectTransform.sizeDelta.y);
                Board.rectTransform.localPosition = new Vector2(-216f + 2.4f * (Globals.p1Life - 10), Board.rectTransform.localPosition.y);
            }
            maxLife = Globals.p1Life;
        }
        else if (gameObject.name == "Enemy Life")
        {
            if (Globals.eTLife > 10f)
            {
                fullLifeBar.rectTransform.sizeDelta = new Vector2(48 + 4.8f * (Globals.eTLife - 10), fullLifeBar.rectTransform.sizeDelta.y);
                fullLifeBar.rectTransform.localPosition = new Vector2(216f - 2.4f * (Globals.eTLife - 10),
                    fullLifeBar.rectTransform.localPosition.y);
                lifeBar.rectTransform.sizeDelta = new Vector2(48 + 4.8f * (Globals.eTLife - 10), lifeBar.rectTransform.sizeDelta.y);
                lifeBar.rectTransform.localPosition = new Vector2(216f - 2.4f * (Globals.eTLife - 10), lifeBar.rectTransform.localPosition.y);
                Board.rectTransform.sizeDelta = new Vector2(68 + 4.8f * (Globals.eTLife - 10), Board.rectTransform.sizeDelta.y);
                Board.rectTransform.localPosition = new Vector2(216f - 2.4f * (Globals.eTLife - 10), Board.rectTransform.localPosition.y);
            }
            maxLife = Globals.eTLife;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "Player Life")
        {
            maxLife = Globals.p1MaxLife;
            if (Globals.p1MaxLife > 10f)
            {
                fullLifeBar.rectTransform.sizeDelta = new Vector2(48 + 4.8f * (Globals.p1MaxLife - 10), fullLifeBar.rectTransform.sizeDelta.y);
                fullLifeBar.rectTransform.localPosition = new Vector2(-216f + 2.4f * (Globals.p1MaxLife - 10),
                    fullLifeBar.rectTransform.localPosition.y);
                lifeBar.rectTransform.sizeDelta = new Vector2(48 + 4.8f * (Globals.p1MaxLife - 10), lifeBar.rectTransform.sizeDelta.y);
                lifeBar.rectTransform.localPosition = new Vector2(-216f + 2.4f * (Globals.p1MaxLife - 10), lifeBar.rectTransform.localPosition.y);
                Board.rectTransform.sizeDelta = new Vector2(68 + 4.8f * (Globals.p1MaxLife - 10), Board.rectTransform.sizeDelta.y);
                Board.rectTransform.localPosition = new Vector2(-216f + 2.4f * (Globals.p1MaxLife - 10), Board.rectTransform.localPosition.y);
            }

            if (Globals.p1Life > maxLife)
                Globals.p1Life = maxLife;
            else if (Globals.p1Life <= 0f)
            {
                Globals.p1Win = false;
                Globals.menuResult = true;
            }
            fullLifeBar.fillAmount = Globals.p1Life / maxLife;
        }
        else if (gameObject.name == "Enemy Life")
        {
            if (Globals.eTLife > maxLife)
                Globals.eTLife = maxLife;
            else if (Globals.eTLife <= 0f)
            {
                Globals.p1Win = true;
                Globals.p1CanAttack = true;
                Globals.eTCanAttack = false;
                if (SceneManager.GetActiveScene().name == "Level 1")
                {
                    //eliminar enemigo y habilitar puerta
                    Enemy.SetActive(false);
                    Cards.SetActive(false);
                    Hit.SetActive(false);
                    Portal.SetActive(true);
                    Globals.e1Died = true;
                }
                else if (SceneManager.GetActiveScene().name == "Level 2")
                {
                    Globals.e2Died = true;
                    Globals.menuResult = true;
                }
            }
            fullLifeBar.fillAmount = Globals.eTLife / maxLife;
        }
    }
}
