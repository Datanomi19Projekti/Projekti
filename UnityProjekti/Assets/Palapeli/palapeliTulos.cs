using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class palapeliTulos : MonoBehaviour
{
    public Text scoreTeksti;
    public Text pistemääräTeksti;
    public Text siirrotTeksti;

    void Start()
    {
        scoreTeksti.text = "Palapelin läpäisemiseen kulunut aika: " + PlayerPrefs.GetString("aika").ToString();
        pistemääräTeksti.text = "Palapelin pistemäärä: " + PlayerPrefs.GetInt("muistipeliScore").ToString();
        siirrotTeksti.text = "Palapelin siirrot yhteensä: " + PlayerPrefs.GetInt("muistipeliSiirrot").ToString();
    }
}
