using UnityEngine;

public class Gutter : MonoBehaviour
{
    private void OnTriggerEnter(Collider triggeredBody)
    {
        Debug.Log("✅ OnTriggerEnter fired! Object entered: " + triggeredBody.name);

        // Check if the collider that entered belongs to the ball
        if (triggeredBody == null)
        {
            Debug.LogError("❌ No Collider detected! Something is wrong with trigger detection.");
            return;
        }

        // We first get the rigidbody of the ball and store it in a local variable
        Rigidbody ballRigidBody = triggeredBody.GetComponent<Rigidbody>();

        if (ballRigidBody == null)
        {
            Debug.LogError("❌ Rigidbody not found on " + triggeredBody.name + ". Ensure the ball has a Rigidbody component!");
            return;
        }
        Debug.Log("✅ Rigidbody found on " + triggeredBody.name);

        // We store the velocity magnitude before resetting the velocity
        float velocityMagnitude = ballRigidBody.linearVelocity.magnitude;
        Debug.Log("🔍 Ball velocity magnitude before reset: " + velocityMagnitude);

        // Check if the ball has any velocity before resetting
        if (velocityMagnitude == 0)
        {
            Debug.LogWarning("⚠️ Ball has zero velocity before reset. It may not have enough speed to be propelled.");
        }

        // Reset linear and angular velocity
        ballRigidBody.linearVelocity = Vector3.zero;
        ballRigidBody.angularVelocity = Vector3.zero;
        Debug.Log("✅ Velocity reset. New velocity: " + ballRigidBody.linearVelocity + ", angular velocity: " + ballRigidBody.angularVelocity);

        // Now we add force in the forward direction of the gutter
        Debug.Log("🚀 Applying force in direction: " + transform.forward + " with magnitude: " + velocityMagnitude);
        ballRigidBody.AddForce(transform.forward * velocityMagnitude, ForceMode.VelocityChange);
        Debug.Log("✅ Force applied!");
        
        // Check if the force applied was significant
        if (velocityMagnitude < 0.2f)
        {
            Debug.LogWarning("⚠️ Applied force is very small. Try increasing the force multiplier.");
        }
    }
}
