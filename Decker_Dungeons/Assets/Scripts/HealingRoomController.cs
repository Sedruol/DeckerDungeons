using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealingRoomController : MonoBehaviour
{
    [SerializeField] private GameObject menuOptions;
    [SerializeField] private Slider slider;
    [SerializeField] private Slider sliderFx;
    [SerializeField] private Text txtTitle;
    [SerializeField] private GameObject arrowFuente;
    [SerializeField] private AudioSource audioFx;
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
    //fade-parpadeo
    IEnumerator fade(GameObject g)
    {
        //cambio el layer a invulnerable, el cual no tiene iteracción con los enemigos
        //gameObject.layer = 10;
        //for (int i = _timesToBlink; i > 0;)
        //{
        while (Globals.firstFuente)
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
        if (Globals.firstFuente)
        {
            arrowFuente.gameObject.SetActive(true);
            StartCoroutine(fade(arrowFuente));
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
        audioFx.volume = Globals.fxVolume;
        txtTitle.text = "You will regain a maximum of 30 life in this room";
        txtTitle.gameObject.SetActive(true);
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
            audioFx.volume = Globals.fxVolume;
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
        if (txtTitle.IsActive())
        {
            vTitle += Time.deltaTime;
            if (vTitle >= 5f)
            {
                txtTitle.gameObject.SetActive(false);
                vTitle = 0;
            }
        }
        if (!Globals.firstFuente)
        {
            StopCoroutine(fade(arrowFuente));
            arrowFuente.SetActive(false);
        }
        //si la señal de flecha es false, flecha de la puerta
    }
}
