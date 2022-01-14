using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    private System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

    public float lifetime = 1f;

    void Start()
    {
        sw.Start();
    }

    void Die()
    {
        tag = "Dying";
    }

    void Update()
    {
        if (sw.ElapsedMilliseconds >= lifetime * 1000) {
            GameObject.Destroy(this.gameObject);
        }
    }
}
