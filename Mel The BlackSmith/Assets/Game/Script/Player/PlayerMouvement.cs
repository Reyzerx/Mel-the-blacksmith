using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    private Rigidbody2D rigidBodyPlayer; 
    private float horizontal;
    private float vertical;
    private float joyHorizontal;
    private float joyVertical;
    private Vector2 joyMovement;
    public Joystick joystick;

    public float speed;

    Animator anim;
    private Vector2 lastMoveDirection;
    private bool facingLeft = false;

    // public Sprite visageObjet;
    // public Sprite visageBas;
    // public Sprite visageGauche;
    // public Sprite visageDroite;
    // public Sprite visageHaut;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBodyPlayer = this.GetComponent<Rigidbody2D>();
        speed = 15f;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // horizontal = Input.GetAxisRaw("Horizontal");
        // vertical = Input.GetAxisRaw("Vertical");

        joyHorizontal = joystick.Horizontal * speed;
        joyVertical = joystick.Vertical * speed;


        //ANIMATION
        if ((joyHorizontal == 0 && joyVertical == 0) && (joyMovement.x != 0 || joyMovement.y != 0))
        {
            lastMoveDirection = joyMovement;
        }

        if (joyMovement.x < 0 && !facingLeft || joyMovement.x > 0 && facingLeft)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
            facingLeft = !facingLeft;
        }

        anim.SetFloat("LastMoveX", lastMoveDirection.x);
        anim.SetFloat("LastMoveY", lastMoveDirection.y);
        anim.SetFloat("speed", joyMovement.sqrMagnitude);
        anim.SetFloat("MoveX", joyMovement.x);
        anim.SetFloat("MoveY", joyMovement.y);
    }

    void FixedUpdate()
    {
        joyMovement = new Vector2(joyHorizontal, joyVertical);//.normalized
        rigidBodyPlayer.linearVelocity = new Vector3(joyMovement.x * speed, joyMovement.y * speed) * Time.fixedDeltaTime;
    }
}
