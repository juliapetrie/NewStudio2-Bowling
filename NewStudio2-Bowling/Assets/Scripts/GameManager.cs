using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;
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
    }
   
}
