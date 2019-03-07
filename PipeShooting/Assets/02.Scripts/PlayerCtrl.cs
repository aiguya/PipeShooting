using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float x;
    public float y;
    public float speed = 10.0f;

    private Rigidbody rb;
    private Vector3 movement;
    private Transform cameraTr;
    private Transform originCameraTr;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraTr = Camera.main.transform;
        originCameraTr = cameraTr;
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        Move(x, y);
    }

    private void Move(float h, float v)
    {
        movement.Set(h, v, 0);
        movement = movement.normalized * speed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
        cameraTr.position = transform.position * 0.5f + new Vector3(0, 0, -15);
    }

    private void LateUpdate()
    {
        transform.rotation = Quaternion.AngleAxis(x * 90.0f, Vector3.back);
    }
}
