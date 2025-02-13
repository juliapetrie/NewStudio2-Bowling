using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;
    [SerializeField] private BallController ball;
    [SerializeField] private GameObject pinCollection;
    [SerializeField] private Transform pinAnchor;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private TextMeshProUGUI scoreText;

    private FallTrigger[] fallTriggers;
    private GameObject pinObjects;

    private void Start()
    {
        // Adding the HandleReset function as a listener to our OnResetPressedEvent
       inputManager.OnResetPressed.AddListener(HandleReset);
        SetPins();
    
    }

    private void HandleReset()
    {
        ball.ResetBall();
        SetPins();
    }

    private void SetPins()
    {
        // Destroy previous pins before creating new ones
        if (pinObjects)
        {
            foreach (Transform child in pinObjects.transform)
            {
                Destroy(child.gameObject);
            }
            Destroy(pinObjects);
        }
        if (fallTriggers != null)
    {
        foreach (FallTrigger pin in fallTriggers)
        {
            pin.OnPinFall.RemoveListener(IncrementScore);
        }
    }
            pinObjects = Instantiate(pinCollection, pinAnchor.transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
            pinObjects.transform.Rotate(0, -270, 0);

            fallTriggers = pinObjects.GetComponentsInChildren<FallTrigger>();

        foreach (FallTrigger pin in fallTriggers)
        {
            pin.OnPinFall.AddListener(IncrementScore);
        }
    }

    private void IncrementScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
    }
}

