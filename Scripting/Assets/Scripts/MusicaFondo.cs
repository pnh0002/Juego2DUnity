using UnityEngine;

public class MusicaFondo : MonoBehaviour
{
    public static MusicaFondo instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;

        DontDestroyOnLoad(this.gameObject);
    }
}
