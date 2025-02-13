// using TMPro;
// using UnityEngine;

// public class GameManager : MonoBehaviour
// {
//     [SerializeField] private float score = 0;
//     // [SerializeField] private TextMeshPro scoreText;
//     [SerializeField] private BallController ball;

//     [SerializeField] private GameObject pinCollection;

//     [SerializeField] private Transform pinAnchor;
//     [SerializeField] private InputManager inputManager;
//     [SerializeField] private TextMeshProUGUI scoreText;

//     private FallTrigger[] pins;
//     private void Start(){
//         //We find all objects of type FallTrigger

//         inputManager.OnResetPressed.AddListener(HandleReset);
//         SetPins();

//         pins = FindObjectsByType<FallTrigger>(FindObjectsSortMode.None); 


//         // Loop through array and add incrementScore function as their listener
//         foreach (FallTrigger pin in pins)
//         {
//             pin.OnPinFall.AddListener(IncrementScore);
//         }
//     }
//     private void IncrementScore()
//     {
//        score++; 
//        scoreText.text = $"Score: {score}";

//     }
   
// }

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
        
        // Find all FallTrigger objects and add IncrementScore listener
        fallTriggers = FindObjectsByType<FallTrigger>(FindObjectsSortMode.None);
        foreach (FallTrigger pin in fallTriggers)
        {
            pin.OnPinFall.AddListener(IncrementScore);
        }
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

        // Instantiate a new set of pins at the pin anchor transform
        // pinObjects = Instantiate(pinCollection, pinAnchor.transform.position, Quaternion.identity, transform);
        // pinObjects = Instantiate(pinCollection, pinAnchor.transform.position, Quaternion.identity);
            pinObjects = Instantiate(pinCollection, pinAnchor.transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
            pinObjects.transform.Rotate(0, -270, 0);




        // Find all new FallTrigger objects and add IncrementScore listener
        // fallTriggers = FindObjectsByType<FallTrigger>(FindObjectsSortMode.None);
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

