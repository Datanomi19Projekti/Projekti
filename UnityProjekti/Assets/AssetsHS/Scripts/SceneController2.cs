using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController2 : MonoBehaviour
{
    [SerializeField] private int gridRows = 2;
    [SerializeField] private int gridCols = 2;    
    [SerializeField] private int Level;
    [SerializeField] private int coloured;
    [SerializeField] private MainCard2 originalCard;
    [SerializeField] private ScoreManager scoremanager;
    [SerializeField] private Sprite EmptyCard;
    [SerializeField] private TextMesh ScoreLabel;
    [SerializeField] private TextMesh LevelLabel;
    [SerializeField] private GameObject LevelCompleted;
    [SerializeField] private GameObject Correct;
    [SerializeField] private Shifts shifts;

    int[] numbers;
    float offsetX = 2f;
    float offsetY = 2f;
    int score;
    int HighScore;
    int beginscore;
    public int choice;

    public List<GameObject> cards = new List<GameObject>();
    GameObject[] Objects;

    private void Start()
    {        
        score = PlayerPrefs.GetInt("GameScore");
        beginscore = score;
        ScoreLabel.text = "Score: " + score;
        LevelLabel.text = "Taso: " + Level;
        LevelCompleted.SetActive(false);
        
        CreateTable();        
        StartCoroutine(WaitAndTurn());
    }
    
    private void CreateTable()
    {
        int CardAmount = gridCols * gridRows;
        int[] numbers = new int[CardAmount];

        numbers = ShuffleArray(numbers);
        Vector3 startPos = originalCard.transform.position;
        for (int i = 0; i < gridCols; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {
                MainCard2 card;
                if (i == 0 && j == 0)
                {
                    card = originalCard;
                }
                else
                {
                    card = Instantiate(originalCard) as MainCard2;
                }
                int index = j * gridCols + i;
                int id = numbers[index];
                if (id < coloured)
                {
                    card.GetComponent<SpriteRenderer>().sprite = Correct.GetComponentInChildren<SpriteRenderer>().sprite;
                }
                else
                {
                    card.GetComponent<SpriteRenderer>().sprite = EmptyCard;
                }
                float posX = (offsetX * i) + startPos.x;
                float posY = (offsetY * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }
    }
    private int[] ShuffleArray(int[] numbers)
    {
        int CardAmount = gridCols * gridRows;
        for (int n = 0; n < CardAmount; n++)
        {
            numbers[n] = n;
        }
        int[] newArray = numbers.Clone() as int[];
        for (int i = 0; i < newArray.Length; i++)
        {
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }
    private IEnumerator WaitAndTurn()
    {
        yield return new WaitForSeconds(1f);
        Objects = GameObject.FindGameObjectsWithTag("card");
        for (int i = 0; i < Objects.Length; i++)
        {
            cards.Add(Objects[i]);
        }
        foreach (GameObject card in cards)
        {
            card.GetComponentInChildren<SpriteRenderer>().sortingOrder = -1;
        }
    }
    public void Scores()
    {
        if (choice == 1)
        {            
            score = PlayerPrefs.GetInt("GameScore");
            score++;
            ScoreLabel.text = "Score: " + score;
            PlayerPrefs.SetInt("GameScore", score);
        }
    
        if (score == beginscore+coloured)
        {           
            StartCoroutine(NextLevel());
        }
    }
    private IEnumerator NextLevel()
    {
        foreach (GameObject card in cards)
        {
            card.SetActive(false);
        }
        LevelCompleted.SetActive(true);
        yield return new WaitForSeconds(4f);
        Level++;
        if (Level == 999)
        {
            Endgame();
        }

        else
        {
            SceneManager.LoadScene("Level" + Level);
        }
    }
    public void Endgame()
    {
        SceneManager.LoadScene("PeliPaattyi");
        scoremanager.UpdateHighScore();
        scoremanager.ResetScore();
    }
}
     
    
    
