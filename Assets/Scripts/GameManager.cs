using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;

    public Text coinText;
    int coins;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        isGameOver = true;

        //LoadScene();

        //Invoke("LoadScene", 2.5f);

        StartCoroutine("LoadScene");
    }

    /*void LoadScene()
    {
        SceneManager.LoadScene(2);
    }*/

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(2.5f);

        SceneManager.LoadScene(2);
    }

    public void AddCoin()
    {
        coins++;
        coinText.text = coins.ToString();
    }
}
