using UnityEngine;
using UnityEngine.Serialization;

public class SpaceShip : MonoBehaviour
{
    // Linear movement
    public float maxSpeed;
    public float aceleration;
    public float friction;
    private float speed;

    // Rotation movement
    public float maxRotationSpeed;
    public float rotationAceleration;
    public float rotationFrict;
    private float rotationXSpeed;
    private float rotationZSpeed;
    private float rotationYSpeed;

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

        speed -= friction * Time.deltaTime;
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

        // Вращение с учетом трения
        if(rotationXSpeed > 0)
        {
            rotationXSpeed -= rotationFrict * Time.deltaTime;
        }
        else if(rotationXSpeed < 0)
        {
            rotationXSpeed += rotationFrict * Time.deltaTime;
        }

        // Rotate about Z axis
        if(Input.GetKey(KeyCode.A))
        {
            rotationZSpeed -= rotationAceleration * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.D))
        {
            rotationZSpeed += rotationAceleration * Time.deltaTime;
        }

        // Вращение с учетом трения
        if(rotationZSpeed > 0)
        {
            rotationZSpeed -= rotationFrict * Time.deltaTime;
        }
        else if(rotationZSpeed < 0)
        {
            rotationZSpeed += rotationFrict * Time.deltaTime;
        }

        rotationXSpeed = Mathf.Clamp(rotationXSpeed, -maxRotationSpeed, maxRotationSpeed);
        rotationZSpeed = Mathf.Clamp(rotationZSpeed, -maxRotationSpeed, maxRotationSpeed); 

        // приращение значения перемещения(дельта)
        Quaternion rot = Quaternion.Euler(rotationXSpeed * Time.deltaTime, rotationYSpeed * Time.deltaTime, rotationZSpeed * Time.deltaTime);
        // изменяем значение премещения перемножив текущий кватернион и приращение
        transform.localRotation = transform.localRotation * rot;
    }
}
