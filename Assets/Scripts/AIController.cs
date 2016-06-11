using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PaddlePhysics))]
public class AIController : MonoBehaviour
{
    public float speed = 10;
    public float acceleration = 15;

    public float slowThreshold = 2;
    public float slowCurve = 2;

    private float currentSpeed;
    private PaddlePhysics AIPhysics;

    // Use this for initialization
    void Start()
    {
        AIPhysics = GetComponent<PaddlePhysics>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameProperties.GetCurrentGame().gameStarted)
        {
            return;
        }

        GameObject ball = GameObject.FindGameObjectWithTag("Ball");

        float distance = ball.transform.position.y - transform.position.y;
        float targetSpeed = Mathf.Sign(distance) * speed;

        if (Mathf.Abs(distance) < slowThreshold)
        {
            targetSpeed /= slowCurve;
        }
        
        
        currentSpeed = MovementHelpers.IncrementToward(currentSpeed, targetSpeed, acceleration);

        Vector2 amountToMove = new Vector2(0, currentSpeed);
        AIPhysics.Move(amountToMove * Time.deltaTime);
    }
}
