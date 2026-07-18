using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager Instance { get; private set; }

    private Stat stats;
    public Stat Stats => stats;


    private void Awake()
    {
        Instance = this;
        stats = new Stat();
    }
}
