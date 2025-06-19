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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBodyPlayer = this.GetComponent<Rigidbody2D>();
        speed = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        // horizontal = Input.GetAxisRaw("Horizontal");
        // vertical = Input.GetAxisRaw("Vertical");

        joyHorizontal = joystick.Horizontal * speed;
        joyVertical = joystick.Vertical * speed;
    }

    void FixedUpdate()
    {
        joyMovement = new Vector2(joyHorizontal, joyVertical);//.normalized
        rigidBodyPlayer.linearVelocity = new Vector3(joyMovement.x * speed, joyMovement.y * speed) * Time.fixedDeltaTime;
    }
}
