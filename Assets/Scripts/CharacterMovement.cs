using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {
    private Rigidbody2D playerRigidbody2D;
    private float movePlayerVector;
    private bool facingRight;
    private GameObject characterSprite;

    private Animator anim;

    public float speed = 4.0f;

	// Use this for initialization
	void Awake () {
        playerRigidbody2D = GetComponent<Rigidbody2D>();

        characterSprite = transform.Find("PlayerSprite").gameObject;
        anim = characterSprite.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        movePlayerVector = Input.GetAxis("Horizontal");
        anim.SetFloat("speed", Mathf.Abs(movePlayerVector));

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

        Vector3 theScale = characterSprite.transform.localScale;
        theScale.x *= -1;
        characterSprite.transform.localScale = theScale;
    }
}
