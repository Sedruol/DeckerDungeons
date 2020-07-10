using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExplorationController : MonoBehaviour
{
    [SerializeField] private GameObject menuOptions;
    [SerializeField] private Slider slider;
    [SerializeField] private Slider sliderFx;
    [SerializeField] private Text txtTitle;
    [SerializeField] private Button markDeck;
    [SerializeField] private GameObject arrowDeck;
    [SerializeField] private GameObject arrowDoor;
    [SerializeField] private GameObject door;
    [Header("Buttons")]
    [SerializeField] private Button btnDeck;
    [SerializeField] private Button btnOptions;
    [SerializeField] private Button btnMusic;
    [SerializeField] private Button btnNoMusic;
    [SerializeField] private Button btnFx;
    [SerializeField] private Button btnNoFx;
    private float tempVolume;
    private float tempFxVolume;
    private AudioSource audioSource;
    private float vTitle;
    private SpriteRenderer srA1;
    private SpriteRenderer srA2;
    private SpriteRenderer srA3;
    //fade-parpadeo
    IEnumerator fade(GameObject g)
    {
        //cambio el layer a invulnerable, el cual no tiene iteracción con los enemigos
        //gameObject.layer = 10;
        //for (int i = _timesToBlink; i > 0;)
        //{
        while (Globals.firstLevel || !Globals.firstLevel)
        {
            g.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            g.SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }
            //i--;
        //}
        //vuelvo a poner el layer como player, el cual si iteractua con los enemigos
        //gameObject.layer = 8;
    }
    private void Awake()
    {
        /*srA1 = arrowDeck.GetComponent<SpriteRenderer>();
        srA2 = arrowDoor.GetComponent<SpriteRenderer>();
        srA3 = markDeck.gameObject.GetComponent<SpriteRenderer>();*/
        //sr = arrowDeck.GetComponent<SpriteRenderer>();
        if (Globals.firstLevel)
        {
            arrowDeck.gameObject.SetActive(true);
            markDeck.gameObject.SetActive(true);
            StartCoroutine(fade(arrowDeck));
            StartCoroutine(fade(markDeck.gameObject));
        }
        else if (!Globals.firstLevel)
        {
            arrowDoor.transform.position = new Vector3(door.transform.position.x + 0.1f, door.transform.position.y + 2.75f,
                door.transform.position.z);
            arrowDoor.gameObject.SetActive(true);
            StartCoroutine(fade(arrowDoor));
            arrowDeck.gameObject.SetActive(false);
        }
        audioSource = GetComponent<AudioSource>();
        slider.value = Globals.volume;
        sliderFx.value = Globals.fxVolume;
    }
    // Start is called before the first frame update
    void Start()
    {
        vTitle = 0f;
        btnOptions.onClick.AddListener(() => GoOptions());
        btnMusic.onClick.AddListener(() => DesactivateMusic());
        btnNoMusic.onClick.AddListener(() => ActivateMusic());
        btnDeck.onClick.AddListener(() => GoSelectCards());
        btnFx.onClick.AddListener(() => DesactivateFx());
        btnNoFx.onClick.AddListener(() => ActivateFx());
        menuOptions.SetActive(false);
        ////
        Globals.volume = slider.value;
        audioSource.volume = Globals.volume;
        Globals.fxVolume = sliderFx.value;
    }

    public void GoSelectCards()
    {
        Globals.lastRoom = SceneManager.GetActiveScene().name;//posible cambio a script door portal
        SceneManager.LoadScene("Select Cards");
    }

    public void DesactivateMusic()
    {
        tempVolume = slider.value;
        slider.value = 0;
    }

    public void ActivateMusic()
    {
        slider.value = tempVolume;
    }

    public void DesactivateFx()
    {
        tempFxVolume = sliderFx.value;
        sliderFx.value = 0;
    }

    public void ActivateFx()
    {
        sliderFx.value = tempFxVolume;
    }

    public void GoOptions()
    {
        Globals.pauseActive = true;
        menuOptions.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Globals.changeVolume)
        {
            Globals.volume = slider.value;
            audioSource.volume = Globals.volume;
            Globals.fxVolume = sliderFx.value;
            if (audioSource.volume > 0f && audioSource.volume <= 1f)
            {
                btnMusic.gameObject.SetActive(true);
                btnNoMusic.gameObject.SetActive(false);
            }
            else if (audioSource.volume == 0f)
            {
                btnMusic.gameObject.SetActive(false);
                btnNoMusic.gameObject.SetActive(true);
            }
            if (sliderFx.value > 0f && sliderFx.value <= 1f)
            {
                btnFx.gameObject.SetActive(true);
                btnNoFx.gameObject.SetActive(false);
            }
            else if (sliderFx.value == 0f)
            {
                btnFx.gameObject.SetActive(false);
                btnNoFx.gameObject.SetActive(true);
            }
        }
        if (Globals.selectYourDeck)
        {
            txtTitle.gameObject.SetActive(true);
            txtTitle.text = "First, select your deck";
            Globals.selectYourDeck = false;
        }
        if (txtTitle.IsActive())
        {
            vTitle += Time.deltaTime;
            if (vTitle >= 2f)
            {
                txtTitle.gameObject.SetActive(false);
                vTitle = 0;
            }
        }
        //si la señal de flecha es false, flecha de la puerta
    }
}
