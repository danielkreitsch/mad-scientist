using System.Collections;
using GameJam;
using UnityEngine;
using Utility;
using Zenject;

public class Zombie : MonoBehaviour
{
    [Inject]
    private GameController gameController;

    [SerializeField]
    private float startHealth = 10;

    [SerializeField]
    private float torqueByBulletFactor = 1;

    private float health = 0;
    private float biomass = 0;

    public bool IsAlive => this.health > 0;

    public float Biomass => this.biomass;

    public Scientist Target { get; set; }

    private void Start()
    {
        this.health = this.startHealth;
        this.biomass = this.health / 10;
    }

    private void OnEnable()
    {
        this.Invoke(() =>
        {
            this.gameController.Zombies.Add(this);
        }, 0.1f);
    }

    private void OnDisable()
    {
        this.gameController.Zombies.Remove(this);
    }

    public void ReceiveShootDamage(float damage, Vector3 direction, Scientist shooter)
    {
        this.health -= damage;
        if (this.IsAlive)
        {
            this.StartCoroutine(this.Blink_Coroutine(0.05f));

            if (shooter.GetComponent<PlayerController>() != null)
            {
                this.GetComponent<ZombieController>().Target = shooter;
                //Debug.Log("Shot by player");
            }
        }
        else
        {
            this.GetComponent<DeadZombie>().enabled = true;
            this.GetComponent<Rigidbody>().AddTorque(direction * torqueByBulletFactor);
        }
    }

    private IEnumerator Blink_Coroutine(float time)
    {
        this.SetVisible(false);
        yield return new WaitForSeconds(time);
        this.SetVisible(true);
    }

    private void SetVisible(bool visible)
    {
        foreach (Renderer renderer in this.GetComponentsInChildren<Renderer>())
        {
            if (visible)
            {
                renderer.transform.localScale = renderer.transform.localScale * 1.15f;
            }
            else
            {
                renderer.transform.localScale = renderer.transform.localScale / 1.15f;
            }
            //renderer.enabled = visible;
        }
    }
}