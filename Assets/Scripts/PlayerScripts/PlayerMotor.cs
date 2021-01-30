using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{

	[SerializeField]
	private Camera cam;

	private Vector3 velocity = Vector3.zero;
	private Vector3 rotation = Vector3.zero;
	private float cameraRotationX = 0f;
	private float currentCameraRotationX = 0f;
	private Vector3 thrusterForce = Vector3.zero;

	private PlayerController pc;

	[SerializeField]
	private float cameraRotationLimit = 85f;

	[Header("CameraWobble")]
	[SerializeField] float stepFrequency;
	[SerializeField] Transform cameraOffset;
	[SerializeField] float frequency;
	[SerializeField] float amplitude;
	public float time;
	float sinWave;
	
	private Rigidbody rb;

	void Start()
	{
		//QualitySettings.vSyncCount = 0;  // VSync must be disabled
		//Application.targetFrameRate = 144;
		rb = GetComponent<Rigidbody>();
		pc = GetComponent<PlayerController>();
	}
	//obeisk
	// Gets a movement vector
	public void Move(Vector3 _velocity)
	{
		velocity = _velocity;
	}

	// Gets a rotational vector
	public void Rotate(Vector3 _rotation)
	{
		rotation = _rotation;
	}

	// Gets a rotational vector for the camera
	public void RotateCamera(float _cameraRotationX)
	{
		cameraRotationX = _cameraRotationX;
	}

	// Get a force vector for our thrusters
	public void ApplyThruster(Vector3 _thrusterForce)
	{
		thrusterForce = _thrusterForce;
	}

	// Run every physics iteration
	void Update()
	{
		PerformRotation();
		PerformMovement();
		CameraSwing();
	}

    //Perform movement based on velocity variable
    void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.deltaTime);
        }

        if (thrusterForce != Vector3.zero)
        {
            rb.AddForce(thrusterForce * Time.deltaTime, ForceMode.Acceleration);
        }
    }

    void PerformRotation()
	{
		//rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
		if (cam != null)
		{
			// Set our rotation and clamp it
			currentCameraRotationX -= cameraRotationX;
			currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

			//Apply our rotation to the transform of our camera
			cam.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
			transform.localEulerAngles += new Vector3(0f, rotation.y, 0f);
		}
	}

	private void CameraSwing()
	{
		if (pc.isWalking)
        {
			sinWave = ((Mathf.Sin(time)*amplitude) - amplitude);
			time += (frequency * pc.speed) * Time.deltaTime;

			cam.transform.localPosition = Vector3.Lerp(cam.transform.localPosition, new Vector3(0f, sinWave + 0.6f, 0f), 0.125f); ;
        } 
		else
        {
			sinWave = 0f;
			time = 0f;
			cam.transform.position = Vector3.Lerp(cam.transform.position, cameraOffset.position, 0.02f);
        }
	}
}