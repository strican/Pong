using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum Identifier
{
    Player,
    Computer,
}

public class GameController : MonoBehaviour
{
    public Transform ball;

    private uint scorePlayer = 0;
    private uint scoreComputer = 0;

    private Text textScorePlayer;
    private Text textScoreComputer;

    // Use this for initialization
    void Start()
    {
        GameObject objectScorePlayer = GameObject.Find("ScorePlayer");
        textScorePlayer = objectScorePlayer.GetComponent<Text>();

        GameObject objectScoreComputer = GameObject.Find("ScoreComputer");
        textScoreComputer = objectScoreComputer.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Score(Identifier scorer)
    {
        BallMovement initialMovement = new BallMovement();

        switch (scorer)
        {
            case Identifier.Player:
                scorePlayer++;
                textScorePlayer.text = scorePlayer.ToString();
                initialMovement.dirX = -1;
                break;

            case Identifier.Computer:
                scoreComputer++;
                textScoreComputer.text = scoreComputer.ToString();
                initialMovement.dirX = 1;
                break;
        }

        GameObject ballObject = Instantiate(ball).gameObject;
        BallController ballController = ballObject.GetComponent<BallController>();
        ballController.currentMovement = initialMovement;
        Debug.Log("Score");
    }
}
