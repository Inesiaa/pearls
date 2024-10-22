using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camChanges : MonoBehaviour
{
    public GameObject mapCamVertical;
    public GameObject mapCamHorizontal;
    public GameObject miniMapHorizontal;
    public GameObject miniMapVertical;

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
        mapCamVertical.SetActive(true);
        mapCamHorizontal.SetActive(false);

        miniMapHorizontal.SetActive(false);
        miniMapVertical.SetActive(true);
    }

    void CameraTwo()
    {
        mapCamHorizontal.SetActive(true);
        mapCamVertical.SetActive(false);

        miniMapHorizontal.SetActive(true);
        miniMapVertical.SetActive(false);
    }
}
