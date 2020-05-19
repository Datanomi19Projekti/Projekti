using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCard2 : MonoBehaviour
{
    [SerializeField] private SceneController2 controller2;
    [SerializeField] private GameObject Card_back2;
    [SerializeField] private GameObject Correct;
    [SerializeField] private TextMesh scoreLabel;
    private string Choice;
    private string Aim;
    private int Score = 0;
    
    public void OnMouseDown()
    {
        //jos kortti on "avattu", eli Card_Back on asetettu taustalle, peli lopetetaan
        if (Card_back2.GetComponent<SpriteRenderer>().sortingOrder == -2)
        {
            controller2.Restart();
        }
        else
        {
            Card_back2.GetComponent<SpriteRenderer>().sortingOrder = -2;
            //verrataan Card_back parentin eli MainCardin kuvan nimeä annettuun kuvaan
            Choice = Card_back2.transform.parent.GetComponent<SpriteRenderer>().sprite.name;
            Aim = Correct.GetComponentInChildren<SpriteRenderer>().sprite.name;

            if (Choice == Aim)
            {
                Score++;
                scoreLabel.text = "Score: " + Score;
            }
            else
            {
                controller2.Restart();
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
