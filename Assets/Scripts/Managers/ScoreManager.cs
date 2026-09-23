using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static PlayerUI playerInterface;

    void Awake ()
    {
        // using 'static' keyword prevents serialization in the editor, so this is the only way to grab the scriptable object.
        // probably increases load time, but it decreases dependancy. is it worth it?
        playerInterface = FindAnyObjectByType<PlayerHealth>().playerInterface;
        playerInterface.Score = 0;
    }
}
