using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _coinText,_livesText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateCoinDisplay(int coins)
    {
        _coinText.text = "Coins " + coins.ToString();
    }
    public void UpdateLivesDisplay(int lives)
    {
        _livesText.text = "Lives: " + lives.ToString();
    }
}
