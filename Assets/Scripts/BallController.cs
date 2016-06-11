using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BallPhysics))]
public class BallController : MonoBehaviour
{
    public float speed = 1;
    
    [HideInInspector]
    public BallMovement currentMovement;
    
    private BallPhysics ballPhysics;

    // Use this for initialization
    void Start()
    {
        ballPhysics = GetComponent<BallPhysics>();
        
        // This may have been initialized by the scoring function.
        // If that's the case, we don't need to override it
        if (currentMovement == null)
        {
            currentMovement = new BallMovement();
        }

        GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameProperties game = GameProperties.GetCurrentGame();
        if (game.gameStarted)
        {
            GetComponent<Renderer>().enabled = true;

            if (!game.gamePaused)
            {
                Vector2 amountToMove = new Vector2(speed * currentMovement.dirX, speed * currentMovement.dirY);
                ballPhysics.Move(amountToMove * Time.deltaTime, out currentMovement);
            }
            else
            {
                // TODO stop the ball
            }
            
        }
        
    }
}

public class BallMovement
{
    public float dirX = -1;
    public float dirY = 1;

    public BallMovement()
    {

    }

    public BallMovement(float x, float y)
    {
        dirX = x;
        dirY = y;
    }
}
