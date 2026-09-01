using UnityEngine;

public class GoldenGrassSpawnCoin : MonoBehaviour
{
    private GoldenCoinObjectPool goldenCoinObjectBool;
    private Grass grass;

    private void Awake()
    {
        goldenCoinObjectBool = FindFirstObjectByType<GoldenCoinObjectPool>();
        grass = GetComponent<Grass>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (grass.IsGrassGolden() != true)
        {
            return;
        }
        if (collision.gameObject.CompareTag("LawnMover") == true || collision.gameObject.CompareTag("Drone") == true)
        {
            var Coin = goldenCoinObjectBool.GetCoin();
            Coin.transform.position = new Vector3(grass.transform.position.x, grass.transform.position.y + 2, grass.transform.position.z);
            Coin.playAnimation();
        }

    }

}
