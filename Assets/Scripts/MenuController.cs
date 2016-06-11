using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Canvas mainMenu;

    // Use this for initialization
    void Start()
    {
        GameObject objectMainMenu = GameObject.Find("MainMenuUI");
        mainMenu = objectMainMenu.GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
        /*
        mainMenu.gameObject.SetActive(false);
        Debug.Log("Start game");

        GameProperties.GetCurrentGame().gameStarted = true;
        */
    }

}
