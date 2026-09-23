using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;

    PlayerInputActions input;
	private Vector2 moveInput;
    private Vector3 movement;
	private Animator anim;
	private Rigidbody playerRigidbody;
	private int floorMask;
	private float camRayLength = 100f;

	void Awake()
	{
        input = new PlayerInputActions();
        floorMask = LayerMask.GetMask("Floor");
		anim = GetComponent<Animator>();
		playerRigidbody = GetComponent<Rigidbody>();
	}

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

	void Start()
	{
		input.Controls.Move.performed += ctx =>
		{
			moveInput = input.Controls.Move.ReadValue<Vector2>();
        };

		input.Controls.Move.canceled += ctx =>
		{
			moveInput = new Vector2(0, 0);
		};
	}

    void FixedUpdate()
	{
		Move(moveInput.x, moveInput.y);
		Turning();
		Animating(moveInput.x, moveInput.y);
	}

	void Move(float h, float v)
	{
		movement.Set(h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;

		playerRigidbody.MovePosition(transform.position + movement);
	}

	void Turning()
	{
		Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit floorHit;

		if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask)) {
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;

			Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
			playerRigidbody.MoveRotation(newRotation);
		}
	}

	void Animating(float h, float v)
	{
		bool walking = h != 0f || v != 0f;

		anim.SetBool(AnimationHasher.IsWalking, walking);
	}
}
