using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMain : MonoBehaviour
{
    #region ComponentScripts
    private Rigidbody rbody;
    #endregion
    #region Obj refs
    [SerializeField] private GameObject cam;
    #endregion
    #region animation parms
    private bool moving;
    #endregion
    private Vector3 displacement;
    private Vector3 direction;
    private Vector3 moveDirection;

    public bool Moving { get => moving; set => moving = value; }
    public Vector3 Direction { get => direction; set => direction = value; }
    public Vector3 MoveDirection { get => moveDirection; set => moveDirection = value; }

    // Start is called before the first frame update
    private void Awake() {
        rbody = GetComponent<Rigidbody>();
    }
    void Start() {

    }
    private void Update() {
        Move();
    }
    #region Action maps
    private void OnMovement(InputValue value) {
        displacement = value.Get<Vector2>();
    }
    private void OnJump() {
        //rbody.AddForce(new)
    }
    private void OnAttack() {

    }
    private void OnBlock() {

    }
    private void OnSkill() {

    }
    #endregion
    #region Methods
    private void Move() {
        Direction = cam.transform.TransformDirection(new Vector3(displacement.x, 0, displacement.y).normalized);
        if (displacement.magnitude >= 0.1f) {
            
                Moving = true;
            
            direction.y = 0;
            Vector3 rot = Vector3.Normalize(Direction);
            rot.y = 0;
            MoveDirection = Quaternion.Euler(rot) * Camera.main.transform.forward;
            transform.rotation = Quaternion.LookRotation(rot);
        }
        else {
            Moving = false;
        }
    }
    #endregion
}
