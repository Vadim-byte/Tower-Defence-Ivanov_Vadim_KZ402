using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour // ????????? ?????? ?? ????????? ?????? ?? ????????? ???????
{


    public float camSpeed;
    public float panSpeed = 30f;
    public float panBoarderTrickness = 10f;

    public float scrollSpeed = 5f;
    public float minY = 15f;
    public float maxY = 80f;

    public float sens;



    // Update is called once per frame
    void Update()
    {



        if (Input.GetKey("w") /* || Input.mousePosition.y >= Screen.height - panBoarderTrickness */ )
        {

            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") /* || Input.mousePosition.y <= panBoarderTrickness */ )
        {

            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") /* || Input.mousePosition.x >= Screen.width - panBoarderTrickness*/ )
        {

            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") /* || Input.mousePosition.x <= panBoarderTrickness*/ )
        {

            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;


    }
       
}

