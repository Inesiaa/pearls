using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camChanges : MonoBehaviour
{
    public GameObject firstPersonCam;
    public GameObject ThirdPersonCam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E))
        //{
          //  firstPersonCam.SetActive(true);
            //ThirdPersonCam.SetActive(false);
        //}
        //else
        //{
          //  firstPersonCam.SetActive(false);
          // ThirdPersonCam.SetActive(true);
        //}

        if(Input.GetKeyDown("1"))
        {
            CameraOne();
        }

        if(Input.GetKeyDown("2"))
        {
            CameraTwo ();
        }
    }

    void CameraOne()
    {
        firstPersonCam.SetActive(true);
        ThirdPersonCam.SetActive(false);
    }

    void CameraTwo()
    {
        ThirdPersonCam.SetActive(true);
        firstPersonCam.SetActive(false);
    }
}
