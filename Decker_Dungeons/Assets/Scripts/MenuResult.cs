using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuResult : MonoBehaviour
{
    public Text result;
    public Button btnTryAgain;
    // Start is called before the first frame update
    void Start()
    {
        btnTryAgain.onClick.AddListener(() => TryAgain());
        if (Globals.p1Win)
            result.text = "You Win";
        else if (!Globals.p1Win)
            result.text = "You Lose";
    }
    public void TryAgain()
    {
        Time.timeScale = 1f;
        Globals.menuResult = false;
        Globals.p1Life = Globals.p1MaxLife;
        Globals.e1Life = 100;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
