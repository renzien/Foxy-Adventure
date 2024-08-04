using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxyMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private float dirX;
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float jumpForce = 10f;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        // Assign Animasi
        if (dirX > 0)
        {
            anim.SetBool("running", true);
            sprite.flipX = false;
        }
        else if (dirX < 0)
        {
            anim.SetBool("running", true);
            sprite.flipX = true;
        }
        else 
        {
            anim.SetBool("running", false);
        }
    }
}
