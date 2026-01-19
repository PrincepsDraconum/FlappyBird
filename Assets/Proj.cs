using System;
using UnityEngine;

public class Proj : MonoBehaviour
{
    public float Speed;
    public bool Deactivated;
    public String Breakabletag;
    public float DeActTime;
    public float AliveTime;
    public void Update()
    {
        if (!Deactivated)
        {
            AliveTime += Time.deltaTime;
            if (AliveTime > 10) Destroy(this.gameObject);
            this.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(Speed, 0);
            foreach (var col in Physics2D.OverlapBoxAll(transform.position, GetComponent<Collider2D>().bounds.size, 0))
            {
                if (col.gameObject.tag == Breakabletag)
                {
                    Deactivated = true;
                    Destroy(col.gameObject);
                }
            }
        }
        else
        {
            this.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, 0);
            this.GetComponent<SpriteRenderer>().enabled = false;
            if (this.GetComponent<ParticleSystem>().isPlaying) this.GetComponent<ParticleSystem>().Stop();
            DeActTime += Time.deltaTime;
            if (DeActTime > 1) Destroy(this.gameObject);
        }
    }

}
