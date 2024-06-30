using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] private HeroStackController _heroStackController;

    private Vector3 direction = Vector3.back;   

    private bool isStack = false;

    private RaycastHit hit;
    
    void Start()
    {
        _heroStackController = GameObject.FindObjectOfType<HeroStackController>();
    }

    void FixedUpdate()
    {
        SetCubeRaycast();
    }

    private void SetCubeRaycast()
    {
        if (Physics.Raycast(transform.position, direction, out hit, 1f))
        {
            if (!isStack)
            {
                isStack = true;
                _heroStackController.IncreaseBlockStack(gameObject);
                SetDirection();
            }

            if (hit.transform.name == "ObstacleCube")
            {
                _heroStackController.DecreaseBlockStack(gameObject);
            }
        }
    }

    private void SetDirection()
    {
        direction = Vector3.forward;
    }
}
