using Unity.Cinemachine;
using UnityEngine;

public class LaunchIndicator : MonoBehaviour
{

    [SerializeField] private CinemachineCamera freeLookCamera;
    [SerializeField] private Transform ball;

    // Update is called once per frame
    void Update()
    {

        //  if (freeLookCamera == null || ball == null) return; 
                transform.position = ball.position + freeLookCamera.transform.forward * 3f; 

        //restrict indicator from dropping below Y axis
  transform.position = new Vector3(transform.position.x, Mathf.Max(transform.position.y, ball.position.y), transform.position.z);

        transform.forward = freeLookCamera.transform.forward;
        transform.rotation = Quaternion.Euler(0,transform.rotation.eulerAngles.y,0);
        // transform.forward = new Vector3(freeLookCamera.transform.forward.x, 0, freeLookCamera.transform.forward.z);
       

        // Debug.Log(transform.rotation.eulerAngles);
    }

}
