using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]
public class BallPhysics : MonoBehaviour
{
    public float skin = 0.05f;
    public LayerMask collisionMask;

    private SphereCollider sphereCollider;
    private Vector3 center;
    private float radius;

    // Use this for initialization
    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        center = sphereCollider.center;
        radius = sphereCollider.radius;


    }

    void Update()
    {

    }

    public void Move(Vector2 amountToMove, out BallMovement currentMovement)
    {
        // Get the current size and center of the object
        Vector2 position = transform.position;

        // Get the direction and magnitude of movement from the move vector
        // We don't expect any x movement, so we'll ignore that
        float deltaX = amountToMove.x;
        float deltaY = amountToMove.y;
        float dirY = Mathf.Sign(deltaY);
        float dirX = Mathf.Sign(deltaX);
        
        // Use the above to calculate the origin of our ray
        float xBase = position.x + center.x;
        float yBase = position.y + center.y;
        float xEdge = dirX * radius;
        float yEdge = dirY * radius;

        // Create the ray
        Ray rayX = new Ray(new Vector2(xBase + xEdge, yBase), new Vector2(dirX, 0));
        Ray rayY = new Ray(new Vector2(xBase, yBase + yEdge), new Vector2(0, dirY));
        Debug.DrawRay(rayX.origin, rayX.direction, Color.red);
        Debug.DrawRay(rayY.origin, rayY.direction, Color.red);

        RaycastHit hitX;
        if (Physics.Raycast(rayX, out hitX, Mathf.Abs(deltaX), collisionMask))
        {
            dirX *= -1;
            /*
            if (hitX.distance > skin)
            {
                deltaX = -1 * dirX * (hitX.distance - skin);
            }
            else
            {
                deltaX = 0;
            }*/
        }

        RaycastHit hitY;
        if (Physics.Raycast(rayY, out hitY, Mathf.Abs(deltaY), collisionMask))
        {
            dirY *= -1;
            /*if (hitY.distance > skin)
            {
                deltaY = dirY * (hitY.distance - skin);
            }
            else
            {
                deltaY = 0;
            }*/
        }

        Vector2 finalTransform = new Vector2(dirX * Mathf.Abs(deltaX), dirY * Mathf.Abs(deltaY));
        currentMovement = new BallMovement(dirX, dirY);
        transform.Translate(finalTransform);
    }
}
