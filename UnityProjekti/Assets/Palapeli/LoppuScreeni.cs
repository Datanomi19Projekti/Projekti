using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoppuScreeni : MonoBehaviour
{
    // Palojen määrä, tällä hetkellä "hardcoded" eli paloja on aina 25 eikä muutu sulavasti katsoen kuinka monta palaa oikeasti on
    public static int remaining = 25;

    // Update is called once per frame
    void Update()
    {
        PeliLoppu();
    }

    public void PeliLoppu()
    {
        if (remaining == 0)
        {
            // Lataa uuden scenen, tällä hetkellä lataa takaisin saman ruudun, tähän voi esim tehdä uuden Loppuruudun
            SceneManager.LoadScene(3);
            // Vaihtaa remaining takaisin 25 (tai myöhemmin palojen "oikean" määrän mukaan)
            remaining = 25;
        }
    }
}
