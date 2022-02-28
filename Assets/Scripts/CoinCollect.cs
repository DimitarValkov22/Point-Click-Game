using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    [SerializeField] AudioSource collectSound;

    private float rotationSpeed = 150f;

    private void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == "Player")
        {
            collectSound.Play();
            Score.coinCount += 1;
            Destroy(gameObject);
            
        }
    }
}
