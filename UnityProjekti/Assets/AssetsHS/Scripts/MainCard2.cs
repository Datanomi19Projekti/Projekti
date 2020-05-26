using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainCard2 : MonoBehaviour
{    
    [SerializeField] private SceneController2 controller2;
    [SerializeField] private ScoreManager scoremanager;
    [SerializeField] private GameObject Card_back2;
    [SerializeField] private GameObject Correct;
    
    public string Choice;
    private string Aim;

    public void OnMouseDown()
    {
        if (Card_back2.GetComponent<SpriteRenderer>().sortingOrder == -2)
        {
            controller2.Endgame();
        }
        else
        {
                Card_back2.GetComponent<SpriteRenderer>().sortingOrder = -2;
                Choice = Card_back2.transform.parent.GetComponent<SpriteRenderer>().sprite.name;
                Aim = Correct.GetComponentInChildren<SpriteRenderer>().sprite.name;
                if (Choice == Aim)
                {
                    controller2.choice = 1;
                    controller2.Scores();
                }
                else
                {
                    controller2.Endgame();
                }
        }  
    }

    private int _id;
    public int id
    {
        get { return _id; }     //palautetaan private _id
    }

    public void ChangeSprite(int id, Sprite image)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }

}
