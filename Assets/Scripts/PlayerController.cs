using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PaddlePhysics))]
public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float acceleration = 15;

    private float currentSpeed;
    private PaddlePhysics playerPhysics;

    // Use this for initialization
    void Start()
    {
        playerPhysics = GetComponent<PaddlePhysics>();
    }

    // Update is called once per frame
    void Update()
    {
        float targetSpeed = Input.GetAxisRaw("Vertical") * speed;
        currentSpeed = MovementHelpers.IncrementToward(currentSpeed, targetSpeed, acceleration);

        Vector2 amountToMove = new Vector2(0, currentSpeed);
        playerPhysics.Move(amountToMove * Time.deltaTime);
    }
}
