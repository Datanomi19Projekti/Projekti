using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Siirtyjä : MonoBehaviour
{

    public void Siirry(int sceneIndex)
    {
        SceneManager.LoadSceneAsync(sceneIndex);
    }

   
}
