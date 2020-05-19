using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    //Voidaan Unityn Inspectorissa asettaa GameObject, jossa koodi sijaitsee
    [SerializeField] private GameObject targetObject;
    //Voidaan Unityn Inspectorissa asettaa metodin nimi
    [SerializeField] private string targetMessage;
    public Color highlightColor = Color.cyan;

    public void OnMouseOver()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if(sprite != null)
        {
            sprite.color = highlightColor;
        }
    }

    public void OnMouseExit()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.color = Color.white;
        }
    }

    public void OnMouseDown()
    {
        transform.localScale = new Vector3(1.2f, 1.2f, 1.0f);
    }

    public void OnMouseUp()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
        if(targetObject != null)
        {
            targetObject.SendMessage(targetMessage);
        }
    }
}
