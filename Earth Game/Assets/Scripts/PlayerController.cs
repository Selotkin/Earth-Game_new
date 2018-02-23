using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 10f;
    public float rotationSpeed = 10f;

    private float rotation;
    private float moveForward;
    private Rigidbody rb;
	private bool playerIsDead = false;

	public bool PlayerIsDead{
		get{ return playerIsDead;}
	}
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rotation = Input.GetAxis("Horizontal");
        moveForward = Input.GetAxis("Vertical");
        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.forward * moveSpeed * Time.fixedDeltaTime * moveForward);
        Vector3 yRotation = Vector3.up * rotation * rotationSpeed * Time.fixedDeltaTime;
        Quaternion deltaRotation = Quaternion.Euler(yRotation);
        Quaternion targetRotation = rb.rotation * deltaRotation;
        rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, 50f * Time.deltaTime));
        //transform.Rotate(0f, rotation * rotationSpeed * Time.fixedDeltaTime, 0f, Space.Self);
    }

	void OnCollisionEnter(Collision collision)
	{	
		if (collision.collider.tag == "Meteor") {
			Destroy (gameObject);
			playerIsDead = true;
		}
			
	}

}
