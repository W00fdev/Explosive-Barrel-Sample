using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{
    [Header("Префаб бочки")]
    public GameObject BarrelPrefab;
    public Transform GunPointTransform;

    [Header("Скорость")]
    public float Speed;
    public Rigidbody RigidbodyComponent;

    [Header("Стрельба")]
    public float ShootingCooldown;
    public float Force;

    private bool _canShoot;
    private float _shootingTime;

    void Start()
    {
        RigidbodyComponent.velocity = transform.forward * Speed;
        _canShoot = true;
    }

    void Update()
    {
        if (_canShoot == false)
        {
            _shootingTime += Time.deltaTime;

            if (_shootingTime >= ShootingCooldown )
            {
                _canShoot = true;
                _shootingTime = 0f;
            }
        }

        if (Input.GetMouseButtonDown(0) && _canShoot == true)
        {
            GameObject barrel = Instantiate(BarrelPrefab, GunPointTransform.position, Quaternion.identity);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            barrel.GetComponent<Rigidbody>().AddForce(ray.direction * Force);

            _canShoot = false;
        }
    }

    private void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
