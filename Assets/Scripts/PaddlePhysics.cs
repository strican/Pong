using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class PaddlePhysics : MonoBehaviour
{
    public float skin = 0.05f;
    public LayerMask collisionMask;
    
    private BoxCollider boxCollider;
    private Vector3 size;
    private Vector3 center;
    
    public void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        size = boxCollider.size;
        center = boxCollider.center;
    }

    public void Move(Vector2 amountToMove)
    {
        // Get the current size and center of the object
        Vector2 position = transform.position;

        // Get the direction and magnitude of movement from the move vector
        // We don't expect any x movement, so we'll ignore that
        float deltaY = amountToMove.y;
        float dir = Mathf.Sign(deltaY);
        
        // Use the above to calculate the origin of our ray
        float x = position.x + center.x;
        float y = position.y + center.y + dir * size.y / 2;

        // Create the ray
        Ray ray = new Ray(new Vector2(x, y), new Vector2(0, dir));
        Debug.DrawRay(ray.origin, ray.direction, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Abs(deltaY), collisionMask))
        {
            if (hit.distance > skin)
            {
                deltaY = dir * (hit.distance - skin);
            }
            else
            {
                deltaY = 0;
            }
        }

        Vector2 finalTransform = new Vector2(0, deltaY);
        transform.Translate(finalTransform);
    }
}
