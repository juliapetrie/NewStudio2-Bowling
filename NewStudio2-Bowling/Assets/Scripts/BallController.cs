using UnityEngine;

public class BallController : MonoBehaviour
{

    [SerializeField] private float force = 1f;
    [SerializeField] private Transform ballAnchor;
    [SerializeField] private Transform launchIndicator;

    // name booleans like a question
    private bool isBallLaunched;
    private Rigidbody ballRB;
    [SerializeField] private InputManager inputManager;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Grabbing a reference to RigidBody
        ballRB = GetComponent<Rigidbody>();

        // Add a listener to the OnSpacePressed event.
        // When the space key is pressed the
        // LaunchBall method will be called.
        inputManager.OnSpacePressed.AddListener(LaunchBall);
      
        ResetBall();

    }

    private void LaunchBall(){
        //now your if check can be framed like a sentence
        // "if ball is launched, then simply return and do nothing"
        if (isBallLaunched) return;
        // "now that the ball is not launched, set it to true and launch the ball"
        isBallLaunched = true;
        transform.parent = null;
        ballRB.isKinematic = false;
        // ballRB.AddForce(transform.forward * force, ForceMode.Impulse);
        ballRB.AddForce(launchIndicator.forward * force, ForceMode.Impulse);
        launchIndicator.gameObject.SetActive(false);

    }

    public void ResetBall()
    {
        isBallLaunched = false;
        //We are setting the ball to be a Kinematic Body
        ballRB.isKinematic = true;
        launchIndicator.gameObject.SetActive(true);
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
    }

    
}
