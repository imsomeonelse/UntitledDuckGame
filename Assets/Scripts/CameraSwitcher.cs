using Cinemachine;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    private int _CurrentCam = 0;

    [SerializeField]
    private CinemachineVirtualCamera[] _Cameras;

    private void Start()
    {
        // Get all child cameras
        _Cameras = GetComponentsInChildren<CinemachineVirtualCamera>();

        // disable all cameras
        foreach (var cam in _Cameras)
        {
            cam.gameObject.SetActive(false);
        }

        // Enable the first one
        _Cameras[0].gameObject.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            LeftCam();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {

            RightCam();
        }
    }

    public void RightCam()
    {
        _Cameras[_CurrentCam].gameObject.SetActive(false);
        _CurrentCam = (_CurrentCam - 1 + 4) % 4;
        _Cameras[_CurrentCam].gameObject.SetActive(true);
    }

    public void LeftCam()
    {
        _Cameras[_CurrentCam].gameObject.SetActive(false);
        _CurrentCam = (_CurrentCam + 1) % 4;
        _Cameras[_CurrentCam].gameObject.SetActive(true);
    }
}
