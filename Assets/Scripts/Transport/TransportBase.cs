using UnityEngine;

public abstract class TransportBase : MonoBehaviour
{
    [SerializeField] protected WheelCollider _frontWheel;
    [SerializeField] protected WheelCollider _backWheel;

    [SerializeField] protected Transform _frontTransfromWheel;
    [SerializeField] protected Transform _backTransfromWheel;

    [SerializeField] protected float _torque;
    [SerializeField] protected float _brakeTorque;
    [SerializeField] protected float _maxSteerAngle;

    protected float _currentSteerAngle;
    protected float _currentBrakingForce;

    protected float _inputX;
    protected float _inputY;

    protected Vector2 _dir;
    protected Camera _cameraMain;

    protected GameObject _pointToMove;


    private Vector3 _moveDir;

    private void Awake()
    {
        _cameraMain = Camera.main;
    }

    private void Start()
    {
        _pointToMove = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Destroy(_pointToMove.GetComponent<SphereCollider>());
        //_pointToMove.transform.SetParent(gameObject.transform);
        _pointToMove.transform.position = transform.position;
    }

    private void FixedUpdate()
    {
        //_inputX = Input.GetAxis("Horizontal");
        //_inputY = Input.GetAxis("Vertical");


        //Vector2 localPos = transform.TransformDirection(InputManager.Instance.TouchHoldDelta);
        //print("Local Dir " + localPos);


        _pointToMove.transform.position = transform.position;




        _dir = new Vector2(InputManager.Instance.TouchHoldDelta.x, InputManager.Instance.TouchHoldDelta.y);

        

        _moveDir = Vector3.zero;
        _moveDir += _cameraMain.transform.right * _dir.x;
        _moveDir += _cameraMain.transform.forward * _dir.y;


        _pointToMove.transform.position = _pointToMove.transform.InverseTransformDirection(transform.position - _moveDir  * 3f);


        Debug.DrawRay(transform.position, _moveDir * 3f, Color.red);







        //Vector2 localPos = InputManager.Instance.TouchHoldDelta;
        //_inputX = localPos.x;
        //_inputY = localPos.y;


        Move();
        //BrakeForce();
        Steer();
        UpdateWheels(); 
    }

    public virtual void Move()
    {
        float magnit = (transform.position - _pointToMove.transform.position).magnitude;



        if (magnit == 0) return;

        float dot = Vector2.Dot(transform.position.normalized, _moveDir.normalized);

        print("DOt " + dot);

        //_frontWheel.motorTorque = 1f * _torque;
        //_backWheel.motorTorque = 1f * _torque;
    }

    public virtual void BrakeForce()
    {
        if (_inputY == 0)
            _currentBrakingForce = _brakeTorque;
        else
            _currentBrakingForce = 0f;

        _frontWheel.brakeTorque = _currentBrakingForce;
        _backWheel.brakeTorque = _currentBrakingForce;
    }

    public virtual void Steer()
    {
        Vector3 relateveVector = transform.InverseTransformPoint(_pointToMove.transform.position);
        float currentWheelAngle = (relateveVector.x / relateveVector.magnitude) * _maxSteerAngle;


        //Vector3 relateveVector = transform.InverseTransformPoint(_dir);
        //float currentWheelAngle = (relateveVector.x / relateveVector.magnitude) * _maxSteerAngle;

        //_frontWheel.steerAngle = _currentSteerAngle;
        _frontWheel.steerAngle = currentWheelAngle;
    }

    public virtual void UpdateWheels()
    {
        UpdateSingleWheel(_frontWheel, _frontTransfromWheel);
        UpdateSingleWheel(_backWheel, _backTransfromWheel);
    }

    protected void UpdateSingleWheel(WheelCollider wheelColider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;

        wheelColider.GetWorldPose(out pos, out rot);

        wheelTransform.position = pos;
        wheelTransform.rotation = rot;
    }

}
