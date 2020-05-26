using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoppuScreeni : MonoBehaviour
{
    // Palojen määrä, tällä hetkellä "hardcoded" eli paloja on aina 25 eikä muutu sulavasti katsoen kuinka monta palaa oikeasti on
    public static int remaining = 25;
    public static int muistipeliScore = 0;
    public static int siirrot = 0;

    private float startTime;
    public static string aika;
    private bool stopTimer = false;

    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        if (!stopTimer)
        {
            PeliLoppu();
        }
    }

    public void PeliLoppu()
    {
        if (remaining == 0)
        {
            stopTimer = true;
            // Vaihtaa remaining takaisin 25 (tai myöhemmin palojen "oikean" määrän mukaan)
            remaining = 25;
            PlayerPrefs.SetInt("muistipeliSiirrot", siirrot);
            siirrot = 0;
            PlayerPrefs.SetInt("muistipeliScore", muistipeliScore);
            muistipeliScore = 0;
            SceneManager.LoadScene(2);
        }
    }

    public void Timer()
    {
        float time = Time.time - startTime;
        float minuutit = ((int)time / 60);
        float sekunnit = (time % 60);
        aika = minuutit.ToString("00") + ":" + sekunnit.ToString("00");
        PlayerPrefs.SetString("aika", aika);
    }
}
