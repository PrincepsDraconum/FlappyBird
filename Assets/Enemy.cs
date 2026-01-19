using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int EnemyType;
    public float Speed;
    public float AliveTime;
    void Update()
    {
        AliveTime += Time.deltaTime;
        if (AliveTime > 10) Destroy(this.gameObject);
        this.GetComponent<Rigidbody2D>().linearVelocity = new Vector3(Speed, 0, 0);
    }
}
