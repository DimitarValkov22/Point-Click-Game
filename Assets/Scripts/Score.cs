using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text coinsCollectedText;

    private Text scoreText;

    public static int coinCount;

    private void Start()
    {
        scoreText = GetComponent<Text>();
    }

    private void Update()
    {
        scoreText.text = "Coins: " + coinCount;
        coinsCollectedText.text = "Coins collected: " + coinCount;
    }
}
