using Unity.Cinemachine;
using UnityEngine;

public class LaunchIndicator : MonoBehaviour
{

    [SerializeField] private CinemachineCamera freeLookCamera;

    // Update is called once per frame
    void Update()
    {
        transform.forward = freeLookCamera.transform.forward;
        transform.rotation = Quaternion.Euler(0,transform.rotation.eulerAngles.y,0);
        // transform.forward = new Vector3(freeLookCamera.transform.forward.x, 0, freeLookCamera.transform.forward.z);

    //     if (freeLookCamera != null)
    // {
    //     Debug.Log("FreeLook Camera Forward: " + freeLookCamera.transform.forward);
    // }
    // else
    // {
    //     Debug.LogError("FreeLook Camera is NULL!");
    // }
        

        Debug.Log(transform.rotation.eulerAngles);
    }

}
