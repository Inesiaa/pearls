using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
          void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Physics.gravity = new Vector3(0f, 1f, 0f);
        }
        else
        {
            Physics.gravity = new Vector3 (0f, 0f, 0f);
        }
    }
}
