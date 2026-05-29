using UnityEngine;
using UnityEngine.InputSystem;

public class Bird : MonoBehaviour
{
    public SpriteRenderer spriteRenderer = null;
    public Sprite flapSprite = null;
    public Sprite fallSprite = null;
    public Rigidbody2D rigidbody = null;
    public float speed = 5f;
    public float xSpeed = 3f;
    public float xDamping = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //[ContextMenu("Start")]
    void Start()
    {
        //spriteRenderer.sprite = fallSprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame || Keyboard.current.wKey.wasPressedThisFrame || Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            rigidbody.linearVelocityY += speed ;
        }
        if (Keyboard.current.dKey.wasPressedThisFrame || Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            rigidbody.linearVelocityX += xSpeed;
        }
        if (rigidbody.linearVelocityY > 0)
        {
            spriteRenderer.sprite = flapSprite;
        }
        else
        {
            spriteRenderer.sprite = fallSprite;
        }
        // Unity's exact 2D damping formula: velocity *= 1 / (1 + dt * damping)
        float dampingFactor = 1.0f / (1.0f + Time.fixedDeltaTime * xDamping);

        float newX = rigidbody.linearVelocity.x * dampingFactor;

        // Apply back to the Rigidbody while leaving Y untouched
        rigidbody.linearVelocity = new Vector2(newX, rigidbody.linearVelocity.y);
    }
}
