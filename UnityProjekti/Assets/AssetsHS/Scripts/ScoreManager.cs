using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    
    [SerializeField] private SceneController2 controller2;
    string time;   
    int highscore1, highscore2, highscore3, highscore4, highscore5, highscore6;
    string time1, time2, time3, time4, time5, time6;
    int score;

    public void ResetScore()
    {
        // UpdateHighScore();
        score = 0;
        PlayerPrefs.SetInt("GameScore", score);
        PlayerPrefs.GetInt("GameScore");
        // scoreText.text = score.ToString();
    }

    public void UpdateHighScore()
    {
        score = PlayerPrefs.GetInt("GameScore");
        highscore1 = PlayerPrefs.GetInt("HighScore1");
         highscore2 = PlayerPrefs.GetInt("HighScore2");
         highscore3 = PlayerPrefs.GetInt("HighScore3");
         highscore4 = PlayerPrefs.GetInt("HighScore4");
         highscore5 = PlayerPrefs.GetInt("HighScore5");
         highscore6 = PlayerPrefs.GetInt("HighScore6");
        time1 = PlayerPrefs.GetString("Time1");
        time2 = PlayerPrefs.GetString("Time2");
        time3 = PlayerPrefs.GetString("Time3");
        time4 = PlayerPrefs.GetString("Time4");
        time5 = PlayerPrefs.GetString("Time5");
        time6 = PlayerPrefs.GetString("Time6");

        Debug.Log("highscore1"+ highscore1);
        Debug.Log("time1" + time1);
        Debug.Log("highscore2" + highscore2);
        Debug.Log("time2" + time2);
        Debug.Log("highscore3" + highscore3);
        Debug.Log("time3" + time3);
        Debug.Log("highscore4" + highscore4);
        Debug.Log("time4" + time4);
        Debug.Log("highscore5" + highscore5);
        Debug.Log("time5" + time5);
        Debug.Log("highscore6" + highscore6);
        Debug.Log("time6" + time6);
        if (score < highscore6)
        {
            int lastscore = score;
        }
        else
        {
            if (score < highscore5)
            {
                highscore6 = score;
                PlayerPrefs.SetInt("HighScore6", score);
                time6 = System.DateTime.UtcNow.ToLocalTime().ToString("dd.MM. HH:mm");
                PlayerPrefs.SetString("Time6", time6);
                
                int h = PlayerPrefs.GetInt("HighScore6");
                Debug.Log("6h"+h);
                string r = PlayerPrefs.GetString("Time6");
                Debug.Log("6time" + r);
                // Highscore6Label.text = h.ToString();
            }
            else
            {
                if (score < highscore4)
                {                    
                    highscore6 = highscore5;
                    PlayerPrefs.SetInt("HighScore6", highscore6);
                    highscore5 = score;                    
                    PlayerPrefs.SetInt("HighScore5", score);

                    time6 = time5;
                    PlayerPrefs.SetString("Time6", time6);
                    time5 = System.DateTime.UtcNow.ToLocalTime().ToString("dd.MM.HH:mm");
                    PlayerPrefs.SetString("Time5", time5);

                    int h = PlayerPrefs.GetInt("HighScore5");                    
                    //Highscore5Label.text = h.ToString();
                    Debug.Log("5h"+h);
                    string r = PlayerPrefs.GetString("Time5");
                    Debug.Log("5time" + r);
                }
                else
                {
                    if (score < highscore3)
                    {
                        highscore6 = highscore5;
                        PlayerPrefs.SetInt("HighScore6", highscore6);
                        highscore5 = highscore4;
                        PlayerPrefs.SetInt("HighScore5", highscore5);
                        highscore4 = score;
                        PlayerPrefs.SetInt("HighScore4", score);

                        time6 = time5;
                        PlayerPrefs.SetString("Time6", time6);
                        time5 = time4;
                        PlayerPrefs.SetString("Time5", time5);
                        time4 = System.DateTime.UtcNow.ToLocalTime().ToString("dd.MM.HH:mm");

                        PlayerPrefs.SetString("Time4", time4);
                        int h = PlayerPrefs.GetInt("HighScore4");
                        // Highscore4Label.text = h.ToString();
                        string r = PlayerPrefs.GetString("Time4");
                        Debug.Log("4time" + r);
                        Debug.Log("4h"+h);
                    }
                    else
                    {
                        if (score < highscore2)
                        {
                            highscore6 = highscore5;
                            PlayerPrefs.SetInt("HighScore6", highscore6);
                            highscore5 = highscore4;
                            PlayerPrefs.SetInt("HighScore5", highscore5);
                            highscore4 = highscore3;
                            PlayerPrefs.SetInt("HighScore4", highscore4);
                            highscore3 = score;
                            PlayerPrefs.SetInt("HighScore3", score);

                            time6 = time5;
                            PlayerPrefs.SetString("Time6", time6);
                            time5 = time4;
                            PlayerPrefs.SetString("Time5", time5);
                            time4 = time3;
                            PlayerPrefs.SetString("Time4", time4);
                            time3 = System.DateTime.UtcNow.ToLocalTime().ToString("dd.MM.HH:mm");
                            PlayerPrefs.SetString("Time3", time3);

                            int h = PlayerPrefs.GetInt("HighScore3");
                            //Highscore1Label.text = h.ToString();
                            string r = PlayerPrefs.GetString("Time3");
                            Debug.Log("3time" + r);
                            Debug.Log("3h"+h);
                        }
                        else
                        {
                            if (score < highscore1)
                            {
                                highscore6 = highscore5;
                                PlayerPrefs.SetInt("HighScore6", highscore6);
                                highscore5 = highscore4;
                                PlayerPrefs.SetInt("HighScore5", highscore5);
                                highscore4 = highscore3;
                                PlayerPrefs.SetInt("HighScore4", highscore4);
                                highscore3 = highscore2;
                                PlayerPrefs.SetInt("HighScore3", highscore3);
                                highscore2 = score;
                                PlayerPrefs.SetInt("HighScore2", score);

                                time6 = time5;
                                PlayerPrefs.SetString("Time6", time6);
                                time5 = time4;
                                PlayerPrefs.SetString("Time5", time5);
                                time4 = time3;
                                PlayerPrefs.SetString("Time4", time4);
                                time3 = time2;
                                PlayerPrefs.SetString("Time3", time3);
                                time2 = System.DateTime.UtcNow.ToLocalTime().ToString("dd.MM.HH:mm");
                                PlayerPrefs.SetString("Time2", time2);

                                int h = PlayerPrefs.GetInt("HighScore2");
                                // Highscore2Label.text = h.ToString();
                                string r = PlayerPrefs.GetString("Time2");
                                Debug.Log("2time" + r);
                                Debug.Log("2h"+h);
                            }
                            if (score >= highscore1)
                            {
                                highscore6 = highscore5;
                                PlayerPrefs.SetInt("HighScore6", highscore6);
                                highscore5 = highscore4;
                                PlayerPrefs.SetInt("HighScore5", highscore5);
                                highscore4 = highscore3;
                                PlayerPrefs.SetInt("HighScore4", highscore4);
                                highscore3 = highscore2;
                                PlayerPrefs.SetInt("HighScore3", highscore3);
                                highscore2 = highscore1;
                                PlayerPrefs.SetInt("HighScore2", highscore2);
                                highscore1 = score;
                                PlayerPrefs.SetInt("HighScore1", score);

                                time6 = time5;
                                PlayerPrefs.SetString("Time6", time6);
                                time5 = time4;
                                PlayerPrefs.SetString("Time5", time5);
                                time4 = time3;
                                PlayerPrefs.SetString("Time4", time4);
                                time3 = time2;
                                PlayerPrefs.SetString("Time3", time3);
                                time2 = time1;
                                PlayerPrefs.SetString("Time2", time2);
                                time1 = System.DateTime.UtcNow.ToLocalTime().ToString("dd.MM.HH:mm");
                                PlayerPrefs.SetString("Time1", time1);

                                int h = PlayerPrefs.GetInt("HighScore1");
                                //Highscore1Label.text = h.ToString();
                                string r = PlayerPrefs.GetString("Time1");
                                Debug.Log("1time" + r);
                                Debug.Log("h1"+h);
                            }                            

                       }

                    }
                }

            }

        }
 
    }
 
}
