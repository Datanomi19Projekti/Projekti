using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiikutaPalaa : MonoBehaviour
{

    public bool isLocked = false;
    public bool checkPlacement = false;

    private float startPosX;
    private float startPosY;
    private bool isBeingHeld = false;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(LoppuScreeni.muistipeliScore);
        /**
         * Kun hiirellä tai sormella pidetään palaa ja se ei ole lukittu, sitä siirretään hiiren tai mukana. Jos hiirellä päästää irti palasta se ei enää seuraa,
         * sormella ei kyseistä ongelmaa tule mutta testaamisen vuoksi täällä liikutetaan palaa myös.
         */
        if (isBeingHeld == true && isLocked == false)
        {

            Vector2 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            checkPlacement = false;

            this.gameObject.transform.localPosition = new Vector2(mousePos.x - startPosX, mousePos.y - startPosY);
            // raahatessa pala on ylimmäisenä, korkeudella 11.
            GetComponent<Renderer>().sortingOrder = 11;
        }
        
    }


    private void OnMouseDown()
    {
        /**
         * Kun hiirellä tai sormella valitaan pala ja pala ei ole lukittu, siirretään sitä hiiren/sormen mukana
         */
        if (Input.GetMouseButtonDown(0) && isLocked == false)
        {

            Vector2 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;
            isBeingHeld = true;
            checkPlacement = false;

         

        }

    }
    /**
     * Kun hiiren painike nostetaan ylös vaihdetaan checkPlacement true:ksi koska silloin haluamme tarkistaa onko pala oikeassa paikassa
     * isBeingHeld false:ksi, koska emme enää kosketa kyseistä palaa
     */
    private void OnMouseUp()
    {

        if (Input.GetMouseButtonUp(0) && isBeingHeld == true)
        {
            isBeingHeld = false;
            checkPlacement = true;
        }
    }



    
        /**
         * Jotain tapahtuu kun palan Collider osuu sitä vastaavaan collider "sockettiin"
         */
    void OnTriggerStay2D(Collider2D other)
    {

        /**
         * Jos palan nimi ja socketin nimi (Molemman GameObjecteja, missä on 2D Collider) ovat samat ja hiirellä tai sormella ei enää pidetä palasta kiinni.
         * pala loksahtaa paikoilleen ja palaa ei voi enää liikutta
         */
        if (other.gameObject.name == gameObject.name && checkPlacement == true)
        {
            // pala siirtyy alimmaiseksi ettei liikuteltavat palat kulje paikalleen asesetut palan alta. Korkeudella 2, koska taustasa olevat kuvat ovat tasoa 0 ja 1
            GetComponent<Renderer>().sortingOrder = 2;
            transform.position = other.gameObject.transform.position;
            isLocked = true;
            checkPlacement = false;
            // Palan läpinäkyvyys vaihtuu 1, eli se on kokonaan näkyvä. Varmistetaan että se on näkyvä joka tapauksessa
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);

            LoppuScreeni.remaining--;
            if (LoppuScreeni.muistipeliScore <= 0)
            {
                LoppuScreeni.muistipeliScore = 0;
            }
            LoppuScreeni.muistipeliScore += 6;
            LoppuScreeni.siirrot++;
        }
        /**
         * Jos palan nimi ja socketin nimi eivät vasta toisiaan, niin pala muuttuu puoliksi läpinäkyväksi ja se ei loksahda paikoilleen, osoittaen että se ei ole oikeassa kohdassa
         */
        else if (other.gameObject.name != gameObject.name && checkPlacement == true && isLocked == false)
        {

            // Jos pala ei ole oikean kohdan päällä, se vaihtuu puoliksi läpinäkyväksi
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .7f);
            checkPlacement = false;
            if (LoppuScreeni.muistipeliScore <= 0)
            {
                LoppuScreeni.muistipeliScore = 0;
            }
            LoppuScreeni.muistipeliScore -= 2;
            LoppuScreeni.siirrot++;
        }
        else
        {
            checkPlacement = false;
        }
    }
}
