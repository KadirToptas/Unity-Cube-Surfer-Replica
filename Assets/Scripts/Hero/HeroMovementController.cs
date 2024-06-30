using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovementController : MonoBehaviour
{
    [SerializeField] private HeroInputController _heroInputController;

    [SerializeField] private float forwardMovementSpeed;

    [SerializeField] private float horizontalMovementSpeed;
    
    [SerializeField] private float horizontalLimitValue;

    private float newPosX;
    
    void FixedUpdate()
    {
        SetHeroForwardMovement();
        SetHeroHorizontalMovement();
    }

    private void SetHeroForwardMovement()
    {
        transform.Translate(Vector3.down * forwardMovementSpeed * Time.fixedDeltaTime);
    }

    private void SetHeroHorizontalMovement()
    {
        newPosX = transform.position.x +
                  _heroInputController.HorizontalValue * horizontalMovementSpeed * Time.fixedDeltaTime;
        newPosX = Mathf.Clamp(newPosX, -horizontalLimitValue, horizontalLimitValue);
        transform.position = new Vector3(newPosX, transform.position.y, transform.position.z);
    }
}
