using DopeAnimals.Extensions;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
namespace GameLogic.Gameplay
{
    public class PlayerController : MonoBehaviour, InputSystem_Actions.IPlayerActions
    {
        bool _isMoving;
        InputSystem_Actions _controls;
        [SerializeField] CharacterController _body;
        public CinemachineCamera Cam { get; set; }
        [field: SerializeField] public float InitialVelocity { get; private set; }
        [field: SerializeField] public float MaxVelocity { get; private set; }
        [field: SerializeField] public float Acceleration { get; private set; }
        void Awake()
        {
            _controls = new InputSystem_Actions();
            _controls.Player.SetCallbacks(this);
        }
        void Start()
        {
            Cam.Target.TrackingTarget = _body.transform;
        }
        void OnEnable()
        {
            if (_controls == null) return;
            _controls.Player.Enable();
        }
        void OnDisable()
        { 
            if (_controls == null) return;
            _controls.Player.Disable();
        }
        public void OnLook(InputAction.CallbackContext context)
        {
            
        }
        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Debug.Log("Interact");
            }
        }
        void Update()
        {
            if (!_isMoving) return;
            _body.Move(MakeRelativeToCamera(GetMoveVector()) * InitialVelocity * Time.deltaTime);
        }
        public void OnMove(InputAction.CallbackContext context)
        {
            if (context.performed) _isMoving = true;
            else if (context.canceled) _isMoving = false;
        }
        Vector3 GetMoveVector() => _controls.Player.Move.ReadValue<Vector2>().ToVector3();
        Vector3 MakeRelativeToCamera(Vector3 vec) => Quaternion.Euler(0, Cam.transform.rotation.eulerAngles.y, 0) * vec;
    }
}