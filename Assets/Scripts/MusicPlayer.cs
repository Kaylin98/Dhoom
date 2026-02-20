using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // This creates a permanent memory of the very first MusicPlayer
    private static MusicPlayer instance;

    // Awake happens BEFORE Start, and BEFORE "Play On Awake" audio triggers
    void Awake()
    {
        // 1. If an instance already exists, and it's not THIS one...
        if (instance != null && instance != this)
        {
            // Instantly destroy this duplicate before it can play a single frame of music
            Destroy(gameObject);
            return;
        }

        // 2. If this is the very first one, claim the "instance" title
        instance = this;

        // 3. Force this object to be a Root object. 
        // (If it has a parent, DontDestroyOnLoad will fail and the music will restart!)
        transform.SetParent(null); 
        
        // 4. Survive scene reloads
        DontDestroyOnLoad(gameObject);
    }
}