using UnityEngine;

public class RoverMovement : MonoBehaviour {
    public bool facingRight = true;
    public bool facingDown = false;
    public float moveForce = 365f;
    public float speed = 10f;

    //private Animator anim;
    private Rigidbody2D rb2d;

	// Use this for initialization
	void Awake ()
    {
        //anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float j = Input.GetAxis("Jump");
        float ySpeed = 0;

        if(v < 0.5 )
        {
            if(j > 0)
            {
                ySpeed = j;
            }
        }
        else
        {
            ySpeed = v;
        }

        Vector2 movement = new Vector2(h, ySpeed);

        rb2d.AddForce(movement * speed);


        if (h > 0 && !facingRight)
        {
            FlipHorizontal();
        }
        else if (h < 0 && facingRight)
        {
            FlipHorizontal();
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y <= 3)
        {
            FlipVertical();
        }
    }

    void FlipHorizontal()
    {
        rb2d.velocity = Vector3.zero;
        facingRight = !facingRight;
        if(facingDown)
        {
            facingDown = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        Vector3 roverScale = transform.localScale;
        roverScale.x *= -1;
        transform.localScale = roverScale;
    }

    void FlipVertical()
    {
        if(facingDown)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            var transformY = transform.lossyScale.x > 0 ? -90 : 90;
            transform.rotation = Quaternion.Euler(0, 0, transformY);

        }
        facingDown = !facingDown;
    }
}
