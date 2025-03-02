using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FoxyMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private float dirX;
    public DialogueUI DialogueUI => dialogueUI;
    public Interactable Interactable { get; set; }
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private DialogueUI dialogueUI;
    private enum MovementState { idle, running, jumping, falling}

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
        rb.linearVelocity = new Vector2(dirX * moveSpeed, rb.linearVelocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        UpdateAnimation();

        // Interact with Character
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interactable?.Interact(this);
        }
    }

    private void UpdateAnimation()
    {
        MovementState state;

        // Assign Animasi
        if (dirX > 0)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else 
        {
            state = MovementState.idle;
        }

        if (rb.linearVelocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.linearVelocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }
}
