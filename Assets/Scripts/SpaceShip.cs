using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    // Linear movement
    public float maxSpeed;
    public float aceleration;
    public float inertion;
    private float speed;

    // Rotation movement
    public float maxRotationSpeed;
    public float rotationAceleration;
    public float rotationInertion;
    private float rotationXSpeed;
    private float rotationZSpeed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LinearMovement();
        RotationMovement();
    }

    private void LinearMovement()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            speed += aceleration * Time.deltaTime;
        }

        speed -= inertion * Time.deltaTime;
        speed = Mathf.Clamp(speed, 0, maxSpeed);

        if(speed > 0)
        {    
            transform.position += transform.up * speed * Time.deltaTime;
        }
    }

    private void RotationMovement()
    {
         // Rotate about X axis
        if(Input.GetKey(KeyCode.W))
        {
            rotationXSpeed += rotationAceleration * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.S))
        {
            rotationXSpeed -= rotationAceleration * Time.deltaTime;
        } 

        // Вращение с учетом инерции
        if(rotationXSpeed > 0)
        {
            rotationXSpeed -= rotationInertion * Time.deltaTime;
        }
        else if(rotationXSpeed < 0)
        {
            rotationXSpeed += rotationInertion * Time.deltaTime;
        }

        // Rotate about Z axis
        if(Input.GetKey(KeyCode.A))
        {
            rotationZSpeed += rotationAceleration * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.D))
        {
            rotationZSpeed -= rotationAceleration * Time.deltaTime;
        }

        // Вращение с учетом инерции
        if(rotationZSpeed > 0)
        {
            rotationZSpeed -= rotationInertion * Time.deltaTime;
        }
        else if(rotationZSpeed < 0)
        {
            rotationZSpeed += rotationInertion * Time.deltaTime;
        }

        rotationXSpeed = Mathf.Clamp(rotationXSpeed, -maxRotationSpeed, maxRotationSpeed);
        rotationZSpeed = Mathf.Clamp(rotationZSpeed, -maxRotationSpeed, maxRotationSpeed); 

        Quaternion rot = Quaternion.Euler(rotationXSpeed * Time.deltaTime, 0, rotationZSpeed * Time.deltaTime);

        transform.localRotation *= rot;
    }
}
