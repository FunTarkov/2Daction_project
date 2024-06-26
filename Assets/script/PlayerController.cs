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

    //一秒間に一定の回数呼ばれる
    void FixedUpdate()
    { 
        // 入力をxに代入
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        //Rigidbody2Dを取得
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        //x軸に加わる力を格納
        Vector2 forceX = new Vector2(horizontalInput * accelPower * Time.deltaTime, 0);
        if (isGrounded()) 
        {
            //Rigidbody2Dに力を加える
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
    //ちゃんとrayが出てるかみるやつ
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, new Vector3(0, -1.35f, 0));
    }
}