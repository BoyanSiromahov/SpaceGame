using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; //debug

public class CameraController : MonoBehaviour
{
    public GameObject track;
    Vector3 wanted_position;
    private float d = 0f;
    public Camera m_OrthographicCamera;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        wanted_position = track.transform.position;
        wanted_position.z = transform.position.z;

        d = Input.GetAxis("Mouse ScrollWheel") * 5;
        if ((m_OrthographicCamera.orthographicSize + d) > 1 && (m_OrthographicCamera.orthographicSize + d) < 20)
        {
            m_OrthographicCamera.orthographicSize += d;
        }

        transform.position = wanted_position;
    }
}
