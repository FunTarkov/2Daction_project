using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float airAratio=0.3f;
    public LayerMask groundLayer;
    public float jumpPower=10;
    public float accelPower=300;

    //ˆê•bŠÔ‚Éˆê’è‚Ì‰ñ”ŒÄ‚Î‚ê‚é
    void FixedUpdate()
    { 
        // “ü—Í‚ğx‚É‘ã“ü
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        //Rigidbody2D‚ğæ“¾
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        //x²‚É‰Á‚í‚é—Í‚ğŠi”[
        Vector2 forceX = new Vector2(horizontalInput * accelPower * Time.deltaTime, 0);
        if (isGrounded()) 
        {
            //Rigidbody2D‚É—Í‚ğ‰Á‚¦‚é
            rb.AddForce(forceX);
        }
        else
        {
            rb.AddForce(forceX*airAratio);
        }
     
        
            if (verticalInput > 0&& isGrounded  () )
                  
            {
                Vector2 velocityY = new Vector2(rb.velocity.x, jumpPower);
                rb.velocity = (velocityY);
            }

            else
            { 
          
            }
        
    }
    void Update() 
    {
    }
    private bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.35f, groundLayer);
        return hit.collider != null;
    }
    //‚¿‚á‚ñ‚Æray‚ªo‚Ä‚é‚©‚İ‚é‚â‚Â
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, new Vector3(0, -1.35f, 0));
    }
}