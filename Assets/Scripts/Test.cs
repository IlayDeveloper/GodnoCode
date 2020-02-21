using UnityEngine;

public class Test : MonoBehaviour
{
    //public Transform myObject;

    public float velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position = transform.position + Vector3.forward * velocity;
        }
        
        // 
    }
}
