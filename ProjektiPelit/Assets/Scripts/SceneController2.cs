using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController2 : MonoBehaviour
{
    //Määritetään rivit ja sarakkeet sekä korttien välit
    public const int gridRows = 2;
    public const int gridCols = 4;
    public const float offsetX = 4f;
    public const float offsety = 5f;

    // tähän kenttään yhdistetään valmiiksi tehty kortti MainCard Unityn Inspectorissa
    [SerializeField] private MainCard2 originalCard;
    // tähä yhdistetään eri kuvat Unityn Inspectorissa
    [SerializeField] private Sprite[] images;
    
    //void Start() sisältämät toiminnot suoritetaan ohjelman alussa siinä järjestyksessä kuin ne on kirjoitettu
    private void Start()
    {
        // valitaan tehdyn kortin sijainti aloitussijainniksi
        Vector3 startPos = originalCard.transform.position;
        
        //Korttien indeksit. Kukin kortti laitetaan Unityn Inspectorissa.
        int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7 };
        // sekoitetaan kortit
        numbers = ShuffleArray(numbers);
        //Luodaan sarakkeet (ulompi for) ja rivit, lisätään kortit
        for (int i = 0; i < gridCols; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {
                MainCard2 card;
                if (i == 0 && j == 0)
                {
                    // ensimmäinen kortti on valmiiksi tehty
                    card = originalCard;
                }
                else
                {
                    // loput korteista kloonataan
                    card = Instantiate(originalCard) as MainCard2;
                }
                //joka toiseen indeksiin vaikuttaa gridCols, joka toiseen vain i: 0, 4, 1, 5, 2, 6, 3, 7
                int index = j * gridCols + i;
                //kuvien indeksit
                int id = numbers[index];
                //vaihdetaan kuva, jonka id images listassa on id
                card.ChangeSprite(id, images[id]);
                //luodaan kortin sijainti
                float posX = (offsetX * i) + startPos.x;
                float posY = (offsetX * j) + startPos.y;
                //asetetaan kortin sijainti
                card.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }

        //siirrytään metodiin, joka odotuttaa hetken ja "kääntää" kortit
        StartCoroutine(WaitAndTurn());
    }
        
    //sekoitetaan numbers-listan numerot eli korttien indeksien järjestys
    private int[] ShuffleArray(int[] numbers)
    {
        //tehdään uusi lista, johon kopioidaan numbers-listan numerot. Alkkuasetelma: 0,1,2,3,4,5,6,7
        int[] newArray = numbers.Clone() as int[];
        //silmukka suoritetaan niin monta kertaa kuin alkioita
        for (int i = 0; i < newArray.Length; i++)
        {
            //tmp tarvitaan, jotta sama alkio tulee vain kerran
            int tmp = newArray[i];
            //r saa satunnaiset arvot väliltä 0 -7
            int r = Random.Range(i, newArray.Length);
            //newArrayn alkio i vaihtaa paikkaa newArrayn alkion r kanssa
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }
    
    
    //luodaan lista, johon lisätään kaikki kortit
    public List<GameObject> cards = new List<GameObject>();
    GameObject[] Objects;

    //odotetaan hetki ja käännetään kortit
    private IEnumerator WaitAndTurn()
    {
        //odotetaan 2 sekuntia (f tarkoittaa, että 2 on float)
        yield return new WaitForSeconds(2f);
        //haetaan GameObjectit, joiden Tad = Basic
        Objects = GameObject.FindGameObjectsWithTag("Basic");
        //lisätään haetut GameObjectit listaan
        for (int i = 0; i < Objects.Length; i++)
        {
            cards.Add(Objects[i]);
        }
        //Vaihdetaan korttien etupuolen Order In Layer -1 eli Card_Back tulee näkyviin
        foreach (GameObject card in cards)
        {
            card.GetComponentInChildren<SpriteRenderer>().sortingOrder = -1;
        }

    }

    //Inspectorissa painikkeen Script: UIButton, Target Object: SceneController Target Message: PlayMuistipeli1
    //Nämä omaksi scripticsi
    public void PlayMuistipeli1()
    {
        SceneManager.LoadScene("Muistipeli1");
    }

    public void PlayMuistipeli2()
    {
        SceneManager.LoadScene("Muistipeli2");
    }

    public void PlayProfiili()
    {
        SceneManager.LoadScene("Kehitys");
    }

    public void PlayMainMenu()
    {
        SceneManager.LoadScene("Aloitusvalikko");
    }
    public void QuitGame()
    {
        Debug.Log("lopeta");
        Application.Quit();
    }
}


