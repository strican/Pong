using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour
{
    public Identifier scorer;

    private GameController gameController;

    // Use this for initialization
    void Start()
    {
        GameObject game = GameObject.Find("GameController");
        gameController = game.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Debug.Assert(other.GetComponent<SphereCollider>() != null);
            Destroy(other.gameObject);
            gameController.Score(scorer);
        }
    }
}
