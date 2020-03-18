using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public static SpaceShip Instance { get; private set; }
    
    public float mass
    {
        get => rigidbody.mass;
    }
    public GameObject explosion; 
    public Rigidbody rigidbody;
    public float maxFuel;
    public float fuelRaschod;
    [SerializeField]private float currentFuel;
    public TMPro.TextMeshProUGUI textFuel;
    public float maxSpeed;
    public float maxRotation;
    public float accelerationLinear;
    public float accelerationRotation;
    
 
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        currentFuel = maxFuel;
        textFuel.text = currentFuel.ToString();
        
        
    }

    private void FixedUpdate()
    {
        if (currentFuel > 0)
        {
            
            LinearMovement();
            
            
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                RotateMovement();
                currentFuel -= fuelRaschod * Time.deltaTime;
            }
            textFuel.SetText(currentFuel.ToString());
        }
    }

    private void LinearMovement()
    {
        if (rigidbody.velocity.magnitude < maxSpeed)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rigidbody.AddForce(transform.forward * accelerationLinear);
            }

            if (Input.GetKey(KeyCode.S))
            {
                rigidbody.AddForce(-transform.forward * accelerationLinear);
            }
        }
    }
    
    private void RotateMovement()
    {
        if(rigidbody.angularVelocity.magnitude < maxRotation)
        {
            if (Input.GetKey(KeyCode.A))
            {
                rigidbody.AddTorque(transform.up * -accelerationRotation);
            }

            if (Input.GetKey(KeyCode.D))
            {
                rigidbody.AddTorque(transform.up * accelerationRotation);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject exp = Instantiate(explosion);
        exp.transform.position = transform.position;
        GameObject.Destroy(gameObject);
        
    }
}
