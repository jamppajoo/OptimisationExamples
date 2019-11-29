using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 10;

    public float jumpSpeed = 10;

    private Vector3 movementDirection = Vector3.zero;

    void Update()
    {
        movementDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            movementDirection -= gameObject.transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movementDirection += gameObject.transform.right;
        }
        if (Input.GetKey(KeyCode.W))
        {
            movementDirection += gameObject.transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movementDirection -= gameObject.transform.forward;
        }
        Turning2();
        Move();
    }

    private void Turning()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, Camera.main.transform.position.y));
        mouseWorldPosition.y = gameObject.transform.position.y;
        gameObject.transform.LookAt(mouseWorldPosition);
    }

    #region Turning2.0

    //Camera.main call is basically GameObject.FindObjectWithTag("MainCamera"); which is unnecessary heavy call
    private Camera mainCamera;
    //Reducing garbage by making variables just once
    private Vector3 mouseScreenPosition2;
    private Vector3 mouseWorldPosition2;

    private void Awake()
    {
        mainCamera = Camera.main;
    }
    private void Turning2()
    {
        mouseScreenPosition2 = Input.mousePosition;
        mouseWorldPosition2 = mainCamera.ScreenToWorldPoint(new Vector3(mouseScreenPosition2.x, mouseScreenPosition2.y, mainCamera.transform.position.y));
        mouseWorldPosition2.y = gameObject.transform.position.y;
        gameObject.transform.LookAt(mouseWorldPosition2);
    }

    #endregion

    private void Move()
    {
        gameObject.transform.localPosition += new Vector3(movementDirection.x, 0, movementDirection.z) * movementSpeed * Time.deltaTime;
    }
}
