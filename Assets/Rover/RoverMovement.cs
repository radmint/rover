using UnityEngine;

public class RoverMovement : MonoBehaviour {
    public bool facingRight = true;
    public bool facingDown = false;
    public float moveForce = 365f;
    public float maxSpeed = 5f;

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
        //anim.SetFloat("Speed", Mathf.Abs(h));

        if(h * rb2d.velocity.x < maxSpeed)
        {
            rb2d.AddForce(Vector2.right * h * moveForce);
        }

        if(Mathf.Abs(rb2d.velocity.x) > maxSpeed)
        {
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
        }

        if(h > 0 && !facingRight)
        {
            FlipHorizontal();
        }
        else if (h < 0 && facingRight)
        {
            FlipHorizontal();
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            FlipVertical();
        }

    }

    void FlipHorizontal()
    {
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
            var transformY = transform.localScale.x > 0 ? -90 : 90;
            transform.rotation = Quaternion.Euler(0, 0, transformY);

        }
        facingDown = !facingDown;
    }
}
