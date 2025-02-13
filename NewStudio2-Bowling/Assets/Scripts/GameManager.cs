using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;
    // [SerializeField] private TextMeshPro scoreText;
    [SerializeField] private TextMeshProUGUI scoreText;

    private FallTrigger[] pins;
    private void Start(){
        //We find all objects of type FallTrigger
        pins = FindObjectsByType<FallTrigger>(FindObjectsSortMode.None); 


        // Loop through array and add incrementScore function as their listener
        foreach (FallTrigger pin in pins)
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
