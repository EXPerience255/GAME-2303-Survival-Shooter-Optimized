using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public PlayerUI playerInterface;
    private Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = "Score: " + playerInterface.Score;
    }
}
