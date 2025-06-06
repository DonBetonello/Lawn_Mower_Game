using UnityEngine;
using TMPro;

public class Flower_Multiplyer_Sript : MonoBehaviour
{
    private bool Flower_Money_Multiplyer = false;
    public bool flower_Money_Multiplyer { get => Flower_Money_Multiplyer; }
    private float Flower_Multiplyer_Timer=60;
    private bool Flower_Multiplyer_Timer_Start_Bool = false;
    private bool Start_Flower_Respawn_Timer;
    private float Flower_Spawn_Timer = 5;
    [SerializeField] private TextMeshProUGUI Flower_Multiplyer_Text;
    [SerializeField] private TextMeshProUGUI Flower_Mutliplyer_Text_TIMER;
    private void FixedUpdate()
    {
        if (Flower_Multiplyer_Timer_Start_Bool == true)
        {
            Flower_Multiplayer_Timer_Start_Void();
        }
        if (Flower_Multiplyer_Timer <= 0)
        {
            Flower_Multiplayer_Timer_End_Void();
        }
        Flower_Respawn_Timer();

        Flower_Mutliplyer_Text_TIMER.text = Flower_Multiplyer_Timer.ToString();
        Flower_Mutliplyer_Text_TIMER.text = Mathf.Round(Flower_Multiplyer_Timer).ToString();
    }
    void Flower_Respawn_Timer()
    {
        if (Start_Flower_Respawn_Timer == true)
        {
            Flower_Spawn_Timer -= Time.deltaTime;
        }
        if (Flower_Spawn_Timer <= 0)
        {
            Start_Flower_Respawn_Timer = false;
            Flower_Respawn();
        }
    }
    void Flower_Respawn()
    {   
        

        transform.position = new Vector3(Random.Range(-1.7f , 1.4f), -4.5f, Random.Range(-2.4f, 2.5f));
        Flower_Spawn_Timer = 1;
    }
    void Flower_Multiplayer_Timer_Start_Void()
    {
        Flower_Multiplyer_Text.gameObject.SetActive(true);
        

        Flower_Multiplyer_Timer -= Time.deltaTime;
        Flower_Money_Multiplyer = true;
        transform.position = new Vector3(10, 10, 10);
    }
    void Flower_Multiplayer_Timer_End_Void()
    {
        Flower_Multiplyer_Timer_Start_Bool = false;
        Flower_Money_Multiplyer = false;
        Flower_Multiplyer_Timer = 60;
        Flower_Multiplyer_Text.gameObject.SetActive(false);

    }
    void Multiplyer_Text_Animation()
    {
        
       
    /*
        Flower_Multiplyer_Text.gameObject.transform.DOShakeRotation(0.3f, 20, 90);
        Flower_Multiplyer_Text.gameObject.transform.DOShakeScale(0.3f, 3, 90);
        Flower_Multiplyer_Text.gameObject.transform.DOShakePosition(0.3f, 3, 90);
    */



    }
    private void OnCollisionEnter(Collision collision)
    {
        Multiplyer_Text_Animation();
        Flower_Multiplyer_Timer_Start_Bool = true;
        Flower_Spawn_Timer = Random.Range(60, 180);
        Start_Flower_Respawn_Timer = true;

    }
}
