using UnityEngine;

public class SpaceBody : MonoBehaviour
{
    // Угловая скорость собсвенного вращения тела
    public float selfRotationSpeed;

    // Угловая скорость вращения на орбите 
    public float orbitRotationSpeed;

    // Центр орбиты
    public Transform centerOfRotation;

    // Радиус вектор от центра вращения до тела
    private Vector3 radius;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    void FixedUpdate() 
    {
        RotateAbouSelfAxis();

        RotateAboutCenter();
    }

    private void RotateAbouSelfAxis()
    {
        transform.rotation *= Quaternion.Euler(0, selfRotationSpeed * Time.deltaTime, 0);
    }

    private void RotateAboutCenter()
    {
        radius = centerOfRotation.position - transform.position;
        
        // Вектор угловой скорости вращения
        Vector3 omega = Vector3.ProjectOnPlane(transform.up, radius).normalized * orbitRotationSpeed * Time.deltaTime;
        // Линейная скорость
        Vector3 linearVelocity = Vector3.Cross(radius, omega);
        // Конечное пермещение за 1 секунду
        Vector3 offset = linearVelocity * Time.deltaTime;

        transform.position += offset;
    }
}
