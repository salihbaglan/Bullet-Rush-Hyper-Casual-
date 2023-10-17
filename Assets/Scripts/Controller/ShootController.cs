using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField] private BulletController bulletPrefabs;
    public Transform bulletSpawnPos;
    public float Delay => delay;
    [SerializeField] float delay;


    public void Shot(Vector3 direction, Vector3 position)
    {
        var bullet = Instantiate(bulletPrefabs, bulletSpawnPos.position, Quaternion.identity);
        bullet.Fire(direction);
    }

}
