using UnityEngine;
[RequireComponent(typeof(PlayerMotor))]

public class PlayerController : MonoBehaviour
{
	[SerializeField] public float speed = 2.5f;
	[SerializeField] private float lookSensitivity = 3f;
    [SerializeField] GameObject torch;
    [SerializeField] Material torchEmission, torchNoEmission;

	public bool isWalking, isRunning;

	private PlayerMotor motor;
    private PlayerSettings settings;
    private Animator onimator;

	void Start()
	{
        //onimator = obeisk.GetComponent<Animator>();

		motor = GetComponent<PlayerMotor>();
        settings = GetComponent<PlayerSettings>();
		Cursor.visible = false;
	}

	void Update()
    {
        CalculateMovement();
        Run();
        TurnTorch();
    }

    private void CalculateMovement()
    {
        //Calculate movement velocity as a 3D vector
        float _xMov = Input.GetAxis("Horizontal");
        float _zMov = Input.GetAxis("Vertical");

        isWalking = (_xMov != 0 || _zMov != 0) ? true : false;

        Vector3 _movHorizontal = transform.right * _xMov;
        Vector3 _movVertical = transform.forward * _zMov;

        // Final movement vector
        Vector3 _velocity = (_movHorizontal + _movVertical);
        _velocity = _velocity.normalized * speed;

        //Apply movement
        motor.Move(_velocity);

        //Calculate rotation as a 3D vector (turning around)
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * settings.playerSense;

        //Apply rotation
        motor.Rotate(_rotation);

        //Calculate camera rotation as a 3D vector (turning around)
        float _xRot = Input.GetAxisRaw("Mouse Y");

        float _cameraRotationX = _xRot * settings.playerSense * 1.5f;

        //Apply camera rotation
        motor.RotateCamera(_cameraRotationX);

        // Calculate the thrusterforce based on player input
        Vector3 _thrusterForce = Vector3.zero;

        // Apply the thruster force
        motor.ApplyThruster(_thrusterForce);
    }

    void Run()
    {
        if (isWalking & Input.GetAxis("Vertical") > 0 & Input.GetKey(KeyCode.LeftShift))
        {
            speed = 4f;
            isRunning = true;
        } else
        {
            speed = 2.5f;
            isRunning = false;
        }
    }

    void TurnTorch()
    {
        torch.GetComponent<Light>().enabled = Input.GetKeyDown(KeyCode.F) ? !torch.GetComponent<Light>().enabled : torch.GetComponent<Light>().enabled;
        torch.GetComponent<MeshRenderer>().material = torch.GetComponent<Light>().enabled ? torchEmission : torchNoEmission;
    }

}
