using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class DroneUpgrade : MonoBehaviour
{
    private Vector3 direction;
    private Vector3 ReflectDirection;
    private bool Isfence = false;
    public bool DroneBoughtTrue { get => DroneBought; }
    [SerializeField] private bool DroneBought = false;
    [SerializeField] private Upgrades MoneySoucre;
    [Range(1.0f, 2.0f, order = 0)]
    [SerializeField] private float DroneSpeed = 1;
    public bool DroneWasteMoney = false;
    public Upgrades DroneVoid;
    [SerializeField] private Button SpeedUpButton;
    private float MaxDroneSpeed = 2f;
    public bool DroneSpeedUpgradeBought = false;
    [SerializeField] Button Drone_Speed_Upgrade_Button;
    [SerializeField] AudioSource UpgradeButtonSound;
    [SerializeField] AudioSource MaxUpgradeButtonSound;
    [SerializeField] private Sound_Change_Button_Script Is_Sound_On;

    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector3(0.3f, 0, 0.3f);
    }
    public void FixedUpdate()
    {
        if (DroneBought == true)
        {
            DronIsBought();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<IsFense>())
        {
            Reflectdirection();
        }
    }
    void Reflectdirection()
    {
        direction = ReflectDirection;
    }
    public void BuyDroneButton()
    {
        if (MoneySoucre.Money >= 1500)
        {
            if (DroneBought == false)
            {
                transform.DOMoveY(-5, 0.0001f);
                DroneBought = true;
                Drone_Speed_Upgrade_Button.interactable = true;
                for (int i = 0; i < 1; i++)
                {
                    DroneVoid.DroneBoughtVoid();
                }
            }
        }
    }
    public void DroneSpeedUpButton()
    {
        if (MoneySoucre.Money >= 500)
        {

            DroneSpeedUpgradeBought = true;
            DroneSpeed += 0.2f;
            if (DroneSpeed >= MaxDroneSpeed)
            {
                SpeedUpButton.interactable = false;
                if (Is_Sound_On.is_Sound_On == true)
                {
                    MaxUpgradeButtonSound.Play();
                }

            }
            else
            {
                if (Is_Sound_On.is_Sound_On == true)
                {
                    UpgradeButtonSound.Play();
                }

            }
        }

    }
    void DronIsBought()
    {

        transform.Translate(direction * DroneSpeed * Time.deltaTime);
        Ray VectorRay = new Ray(transform.position, direction * 10f);
        RaycastHit VectorHit;
        Debug.DrawRay(transform.position, direction * 10f, Color.red);
        Debug.DrawRay(transform.position, ReflectDirection * 100f, Color.blue);
        if (Physics.Raycast(VectorRay, out VectorHit))
        {
            ReflectDirection = Vector3.Reflect(direction, VectorHit.normal);
        }
        if (VectorHit.collider.GetComponent<IsFense>())
        {
            Isfence = true;
        }
        DroneWasteMoney = true;
    }
}
