using UnityEngine;

public class BulletCaster : MonoBehaviour
{
    public float fireRate = 0.05f;

    public Bullet BulletPrefab;
    public Transform bulletSource;
    public Animator AimAnimator;

    private float _timer;

    private Animator _charAnimator;

    private void Start()
    {
        InitAnimators();
    }

    void Update()
    {
        AimAnimator.SetBool("Aiming", false);
        _charAnimator.SetBool("Aiming", false);
        _charAnimator?.SetFloat("ShootingOrNot", 0);


        _timer -= Time.deltaTime;
        if (Input.GetMouseButton(0) && _charAnimator?.GetFloat("RunningOrNot") < 0.5)
        {
            _charAnimator?.SetFloat("ShootingOrNot", 1);
            if (_timer <= 0)
            {
                _timer = fireRate;
                Shoot();
            }
        }
        Aiming();
    }

    private void InitAnimators()
    {
        if (transform.childCount == 0) return;
        var child = transform.GetChild(0).gameObject;

        _charAnimator = child.GetComponent<Animator>();
        if (!_charAnimator)
            _charAnimator = child.AddComponent<Animator>();
    }

    private void Aiming()
    {
        if (Input.GetMouseButton(1) && _charAnimator?.GetFloat("RunningOrNot") < 0.5)
        {
            AimAnimator.SetBool("Aiming", true);
            _charAnimator?.SetBool("Aiming", true);
        }
    }

    private void Shoot()
    {
        
        Instantiate(BulletPrefab, bulletSource.position, bulletSource.rotation);
    }
}
