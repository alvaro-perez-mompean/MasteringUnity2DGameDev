using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {
    private Rigidbody2D playerRigidbody2D;
    private float movePlayerVector;
    private bool facingRight;

    public float speed = 4.0f;

	// Use this for initialization
	void Awake () {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        movePlayerVector = Input.GetAxis("Horizontal");

        playerRigidbody2D.velocity = new Vector2(movePlayerVector * speed, playerRigidbody2D.velocity.y);

        if (movePlayerVector > 0 && !facingRight)
        {
            Flip();
        } else if (movePlayerVector < 0 && facingRight)
        {
            Flip();
        }
	}

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
