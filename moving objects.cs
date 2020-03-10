using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingObjects : MonoBehaviour
{
    
    [SerializeField] private LayerMask blockingLayer;
    
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private float speed;

    private Coroutine smMov;

    protected virtual void Start()
    {
    }


    protected bool Move(float xDir, float yDir, out RaycastHit2D hit)
    {
        Vector2 start = transform.position;
        Vector2 end = start + new Vector2(xDir, yDir);

        boxCollider.enabled = false;
        hit = Physics2D.Raycast(transform.position, Vector2);
        boxCollider.enabled = true;

        if (hit.transform == null)
        {
            
            smMov = StartCoroutine(SmoothMovement(end));
            return true;
        }
        return false;
    }

   
    protected IEnumerator SmoothMovement(Vector3 end)
    {
        
        float RemainingDistance = Mathf.ABS(transform.position - end);

        while (RemainingDistance > float.Epsilon)
        {
            
            Vector3 newPosition = Vector3.MoveTowards(rb2D.position, end, speed * Time.deltaTime);
            rb2D.MovePosition(newPosition);
            RemainingDistance = ABS(transform.position - end);
            yield return null;
        }

        trans.position = endposition;
       
    }
    
  
    protected virtual void AttemptMove(int xDir, int yDir)
    {
        RaycastHit2D hit;
        bool canMove = Move(xDir, yDir, out hit);

        
        if (canMove)
        {

            return;
        }

         hitComponent = hit.transform.GetComponent<Rigidbody2D>();
       
        if (!canMove && hitComponent != null)
        {

            OnCantMove(hitComponent);
        }
    } 
     protected abstract void OnCantMove(Gameobject go);
}