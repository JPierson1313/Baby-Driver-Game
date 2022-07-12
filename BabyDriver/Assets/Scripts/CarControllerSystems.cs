using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControllerSystems : MonoBehaviour
{
    [Header("Car Controller Variables")]
    [SerializeField] float forwardSpeed = 0;
    [SerializeField] int maxSpeed = 30;
    [SerializeField] int minSpeed = 5;
    [SerializeField] float drag = 0.98f;
    [SerializeField] float turningAngle = 20;
    [SerializeField] float traction = 1;

    private Vector3 moveForce;
    private float turningInput;
    private int turningButtonInput;
    private bool iJarTurningButtonTouched = false;
    private bool iJarBrakeButtonTouched = false;

    [Header("Score Systems")]
    [SerializeField] TimerScoreSystems timerScoreSystems;

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKey(KeyCode.S) && forwardSpeed < maxSpeed && iJarBrakeButtonTouched == false)
        {
            forwardSpeed += 0.1f;
        }

        else if (Input.GetKey(KeyCode.Space) || iJarBrakeButtonTouched == true)
        {
            forwardSpeed = minSpeed;
        }
    }

    void FixedUpdate()
    {
        moveForce += transform.forward * forwardSpeed * Time.deltaTime;
        gameObject.GetComponent<Rigidbody>().velocity = moveForce;

        if (iJarTurningButtonTouched)
        {
            turningInput = turningButtonInput;
        }
        else
        {
            turningInput = Input.GetAxis("Horizontal");
        }

        transform.Rotate(Vector3.up * turningInput * moveForce.magnitude * turningAngle * Time.deltaTime);

        moveForce *= drag;
        moveForce = Vector3.ClampMagnitude(moveForce, forwardSpeed);
        moveForce = Vector3.Lerp(moveForce.normalized, transform.forward, traction * Time.deltaTime) * moveForce.magnitude;
    }
    
    public void LeftButtonPressed()
    {
        iJarTurningButtonTouched = true;
        turningButtonInput = -1;
    }

    public void RightButtonPressed()
    {
        iJarTurningButtonTouched = true;
        turningButtonInput = 1;
    }

    public void LeftButtonReleased ()
    {
        iJarTurningButtonTouched = false;
        turningButtonInput = 0;
    }

    public void RightButtonReleased()
    {
        iJarTurningButtonTouched = false;
        turningButtonInput = 0;
    }

    public void BrakeButtonPressed()
    {
        iJarBrakeButtonTouched = true;
    }

    public void BrakeButtonReleased()
    {
        iJarBrakeButtonTouched = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Building")
        {
            timerScoreSystems.score -= 250;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Blockade")
        {
            timerScoreSystems.score -= 500;
            forwardSpeed = minSpeed;
        }
    }
}
