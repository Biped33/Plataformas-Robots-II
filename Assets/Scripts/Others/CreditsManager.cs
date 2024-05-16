using UnityEngine;
using TMPro;

public class CreditsManager : MonoBehaviour
{
    public static CreditsManager instance; 

    public TMP_Text creditsText; 
    public int creditsCount = 0; 

    private void Awake()
    {
       
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    private void Start()
    {
        UpdateCreditsText();
    }

    
    public void AddCredits(int amount)
    {
        creditsCount += amount;
        UpdateCreditsText();
    }

   
    public void RemoveCredits(int amount)
    {
        creditsCount -= amount;
        if (creditsCount < 0)
        {
            creditsCount = 0;
        }
        UpdateCreditsText();
    }

    
    private void UpdateCreditsText()
    {
        creditsText.text = "Créditos: " + creditsCount;
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Return))
        {
            AddCredits(1);
        }
    }
}