using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 1;
    public BoxCollider2D bc;
    public float distanceDetection = 0.5f;
    public LayerMask obstaclesLayer;
    public bool isFacingRight = true;

    void Start()
    {
        
    }

    private void Update() 
    {
        isFacingRight = !isFacingRight;   
    }

    private void fixedUpdate()
    {
        rb.velocity = new Vector2(
            speed,
            rb.velocity.y
        );
    }

      public void Flip() {
        if (
            (transform.rotation.y > 0 && !isFacingRight) ||
            (transform.rotation.y <= 0 && isFacingRight)
        )
        {
            transform.Rotate(0, 180, 0);
            
        }
    }

    private void OnDrawGizmos()
    {
        if (bc != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(
                bc.bounds.center,
                bc.bounds.center + new Vector3(2, 0, 0)
            );
        }
    }

    public bool HasCollisionWithObstacle()
    {
        RaycastHit2D hit = Physics2D.Linecast(
            bc.bounds.center,
            bc.bounds.center + new Vector3(distanceDetection, 0,0),
            obstaclesLayer
        );

        return hit.collider != null;
    }

}
