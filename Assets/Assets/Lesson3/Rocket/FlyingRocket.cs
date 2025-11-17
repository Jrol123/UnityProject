using System.Collections;
using UnityEngine;

public class FlyingRocket : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float detonationTime;
    [SerializeField] GameObject explosion;
    [SerializeField] DamageType damageType;

    void Awake()
    {
        StartCoroutine(Move());
        StartCoroutine(Detonate());
    }


    IEnumerator Move()
    {
        while (true)
        {
            transform.position += transform.forward * speed * Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
    }
    IEnumerator Detonate()
    {
        yield return new WaitForSeconds(detonationTime);
        Detonation();
    }

    void Detonation()
    {
        Debug.Log("Detonated");
        Destroy(Instantiate(explosion, transform.position, transform.rotation), explosion.GetComponent<ParticleSystem>().main.duration);

        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            var hp = collision.gameObject.GetComponent<Health>();
            hp.TakeDamage(damageType);
            Detonation();
        }
    }
}
