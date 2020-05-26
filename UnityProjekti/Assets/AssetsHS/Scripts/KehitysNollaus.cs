using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KehitysNollaus : MonoBehaviour
{
    [SerializeField] private Text TimeLabel1;
    [SerializeField] private Text TimeLabel2;
    [SerializeField] private Text TimeLabel3;
    [SerializeField] private Text TimeLabel4;
    [SerializeField] private Text TimeLabel5;
    [SerializeField] private Text TimeLabel6;
    [SerializeField] private Text Highscore1Label;
    [SerializeField] private Text Highscore2Label;
    [SerializeField] private Text Highscore3Label;
    [SerializeField] private Text Highscore4Label;
    [SerializeField] private Text Highscore5Label;
    [SerializeField] private Text Highscore6Label;
    int highscore1, highscore2, highscore3, highscore4, highscore5, highscore6;
    string time1, time2, time3, time4, time5, time6;

    public void ClearHighScore()
    {
        PlayerPrefs.SetInt("HighScore1", 0);
        highscore1 = PlayerPrefs.GetInt("HighScore1");
        Highscore1Label.text = highscore1.ToString();        
        PlayerPrefs.SetInt("HighScore2", 0);
        highscore2 = PlayerPrefs.GetInt("HighScore2");
        Highscore2Label.text = highscore2.ToString();
        PlayerPrefs.SetInt("HighScore3", 0);
        highscore3 = PlayerPrefs.GetInt("HighScore3");
        Highscore3Label.text = highscore3.ToString();
        PlayerPrefs.SetInt("HighScore4", 0);
        highscore4 = PlayerPrefs.GetInt("HighScore4");
        Highscore4Label.text = highscore4.ToString();
        PlayerPrefs.SetInt("HighScore5", 0);
        highscore5 = PlayerPrefs.GetInt("HighScore5");
        Highscore5Label.text = highscore5.ToString();
        PlayerPrefs.SetInt("HighScore6", 0);
        highscore6 = PlayerPrefs.GetInt("HighScore6");
        Highscore6Label.text = highscore6.ToString();

        PlayerPrefs.SetString("Time1", " ");
        time1 = PlayerPrefs.GetString("Time1");
        TimeLabel1.text = time1;
        PlayerPrefs.SetString("Time2", " ");
        time2 = PlayerPrefs.GetString("Time2");
        TimeLabel2.text = time2;
        PlayerPrefs.SetString("Time3", " ");
        time3 = PlayerPrefs.GetString("Time3");
        TimeLabel3.text = time3;
        PlayerPrefs.SetString("Time4", " ");
        time4 = PlayerPrefs.GetString("Time4");
        TimeLabel4.text = time4;
        PlayerPrefs.SetString("Time5", " ");
        time5 = PlayerPrefs.GetString("Time5");
        TimeLabel5.text = time5;
        PlayerPrefs.SetString("Time6", " ");
        time6 = PlayerPrefs.GetString("Time6");
        TimeLabel6.text = time6;

    }

}
