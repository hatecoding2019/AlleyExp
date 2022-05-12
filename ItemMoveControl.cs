using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMoveControl : MonoBehaviour
{
    [SerializeField] KeyCode codeUp;
    [SerializeField] KeyCode codeDown;
    [SerializeField] float Speed;
    private void Update()
    {
        if (Input.GetKey(codeUp))
        {
            transform.Translate(Vector3.forward * Speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(codeDown))
        {
            transform.Translate(Vector3.back * Speed * Time.deltaTime, Space.World);
        }
    }
}
