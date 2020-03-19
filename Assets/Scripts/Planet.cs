using System;
using UnityEngine;

public class Planet : MonoBehaviour
{
    // Угловая скорость собсвенного вращения тела
    public float selfRotationSpeed;

    // Угловая скорость вращения на орбите 
    public float orbitRotationSpeed;

    // Центр орбиты
    public Transform centerOfRotation;

    // Радиус вектор от центра вращения до тела
    private Vector3 radius;
    private float radiusLenght;

    private void Awake()
    {
        // Находим на старте длину радиуса орбиты
        radiusLenght = (transform.position - centerOfRotation.position).magnitude;
    }

    void Update() 
    {
        RotateAbouSelfAxis();
        RotateAboutCenter();
    }

    private void RotateAbouSelfAxis()
    {
        transform.localRotation *= Quaternion.Euler(0, selfRotationSpeed * Time.deltaTime, 0);
    }

    private void RotateAboutCenter()
    {
        if(centerOfRotation == null || orbitRotationSpeed == 0) return;
        
        radius = transform.position - centerOfRotation.position;

        // Плоскость вращения
        Vector3 planeOfRotation = centerOfRotation.up;
        // Вектор угловой скорости вращения
        Vector3 omega = planeOfRotation * orbitRotationSpeed * Time.deltaTime;
        // Вектор линейной скорости
        Vector3 linearVelocity = Vector3.Cross(radius, omega);
        // Конечное пермещение за 1 секунду
        Vector3 delta = linearVelocity * Time.deltaTime;

        //transform.position += delta;
        // Новая позиция относительно центра вращения
         Vector3  newPos = radius + delta;
 
         // Ограничение длины вектора новой позиции на длину радиуса орбиты
         newPos = Vector3.ClampMagnitude(newPos, radiusLenght);
 
         // Складываем позицию центра вращения и новой позиции планеты относительно центра вращения
         transform.position = newPos + centerOfRotation.position;
    }
}
