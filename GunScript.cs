using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

//silah sürekli olarak aşağıya çekiyor!!!
public class GunScript : MonoBehaviour
{

    public static GunScript GunInstance;

    public Animator animator;
    public Camera playerCam;
    public Rigidbody pistolRB;
    public GameObject playercam2;
    public GameObject player;
    public GameObject pistol;
    //public GameObject impactEffect;
    public GameObject gunLocation;
    public GameObject bullet;
    public GameObject bullet2;
    public GameObject bulletSpawn;
    public GameObject pistolExitPoint;
    public Vector3 hipFire;
    public ParticleSystem muzzleFlash;


    public float damage = 50f;
    public float secondaryDamage = 120f;
    public float fireRate = 15f;
    public float secondaryFireRate;
    public float range = 100f;
    public float impactForce = 30f;
    public float secondaryİmpactForce = 100f;
    public float currentAmmo;
    public float maxAmmo = 15f;
    public float bulletSpeed = 170f;
    public float bulletSpeed2 = 200f;
    public float bulletSpeed3 = 240f;
    public float bulletSpeed4 = 290f;
    public float throwDamage;


    private float throwForce;
    private float nextTimeToFire = 0f;
    private float nextTimeToFireSecondary = 0f;

    public bool isReloading = false;
    public bool isEquiped;
    public bool isShooting;
    public bool whichBullet;


    private void Awake()
    {
        if(GunInstance = null)
        {
            GunInstance = this;
        }
        else
        {
            return;
        }
    }
    public void Start()
    {
        isEquiped = true;
        currentAmmo = maxAmmo;

    }
    



    // Update is called once per frame
    void Update()
    {

        if(FindObjectOfType<PauseMenuScript>().gameIsPaused == false)
        {
            GunAlertChecker();
            PistolThrow();
            ThrowDamageCalculator();
            AnimationController();


            if (isEquiped == true && !isReloading)
            {
                PistolFire();
                PistolFire2();
            }
        }




        hipFire.x = 0f; hipFire.y = 0f; hipFire.z = 0f;
        currentAmmo = Mathf.Clamp(currentAmmo, -10f, 15f);
    }

    public void PistolFire()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.time >= nextTimeToFire && currentAmmo > 0f && isReloading == false)
        {
            if (AudioManager.audioinstance != null)
            {
                AudioManager.audioinstance.PlayC("Shoot1");

            }
            else
            {
                return;
            }
            whichBullet = true;
            animator.SetTrigger("Shoot");
            currentAmmo--;
            nextTimeToFire = Time.time + 1f / fireRate;

            muzzleFlash.Play();
            Shoot();



        }
    }
    public void PistolFire2()
    {
        if (Input.GetKey(KeyCode.Mouse1) && Time.time >= nextTimeToFireSecondary && currentAmmo >= 3f && isReloading == false)
        {
            if (AudioManager.audioinstance != null)
            {
                AudioManager.audioinstance.PlayC("Shoot1");

            }
            else
            {
                return;
            }
            whichBullet = false;
            
            animator.SetTrigger("Shoot");
            currentAmmo -= 3f;
            nextTimeToFireSecondary = Time.time + 1f / secondaryFireRate;

            muzzleFlash.Play();
            Shoot2();

        }
    }

    public void Shoot()
    {
        GameObject bulletInstance = Instantiate(bullet, bulletSpawn.transform.position, bullet.transform.rotation);
        bulletInstance.transform.rotation = Quaternion.LookRotation(bulletSpawn.transform.forward);
        Rigidbody bulletRig = bulletInstance.GetComponent<Rigidbody>();

        //FindObjectOfType<BulletDamageScript>().bulletDamage = 50f;

        if (FindObjectOfType<PlayerMovement>().isSprinting == false)
        {
            bulletRig.AddForce(playerCam.transform.forward * bulletSpeed, ForceMode.Impulse);
        }
        if (FindObjectOfType<PlayerMovement>().isSprinting == true)
        {
            bulletRig.AddForce(playerCam.transform.forward * bulletSpeed2, ForceMode.Impulse);
        }
    }
    public void Shoot2()
    {

        GameObject bulletInstance = Instantiate(bullet2, bulletSpawn.transform.position, bullet.transform.rotation);
        bulletInstance.transform.rotation = Quaternion.LookRotation(bulletSpawn.transform.forward);
        Rigidbody bulletRig = bulletInstance.GetComponent<Rigidbody>();

        //FindObjectOfType<BulletDamageScript>().bulletDamage = 120f;

        if (FindObjectOfType<PlayerMovement>().isSprinting == false)
        {
            bulletRig.AddForce(playerCam.transform.forward * bulletSpeed3, ForceMode.Impulse);
        }
        if (FindObjectOfType<PlayerMovement>().isSprinting == true)
        {
            bulletRig.AddForce(playerCam.transform.forward * bulletSpeed4, ForceMode.Impulse);
        }
    }



    public void AnimationController()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            isReloading = true;
            animator.SetTrigger("Reload");
        }

    }

    public void PistolReload()
    {
        currentAmmo = maxAmmo;
        isReloading = false;
    }


    public void GunAlertChecker()
    {
        if (isEquiped)
        {

            pistol.transform.localPosition = hipFire;
            pistolRB.Sleep();
            pistol.transform.localScale = new Vector3(1f, 1f, 1f);
            pistol.transform.forward = gunLocation.transform.forward;
        }
    }
    public void PistolThrow()
    {
        if (Input.GetKeyDown(KeyCode.E) && isEquiped)
        {
            animator.enabled = false;
            Invoke("ParentSeparater", .01f);
            Invoke("Pistolimpulser", .021f);
        }
        if (Input.GetKeyDown(KeyCode.E) && !isEquiped)
        {
            Invoke("Parenter", 0.02f);            
        }
    }
    public void ParentSeparater()
    {
        pistolRB.WakeUp();
        pistolRB.isKinematic = false;
        
        isEquiped = false;
        pistol.transform.parent = null;
        pistol.transform.localScale = new Vector3(0.25f, .25f, .25f);           
    }
    public void Parenter()
    {
        pistol.transform.parent = gunLocation.transform;
        animator.enabled = true;
        pistolRB.isKinematic = true;
        isEquiped = true;
    }
    public void Pistolimpulser()
    {
        pistol.transform.forward = gunLocation.transform.forward;
        if (FindObjectOfType<PlayerMovement>().isSprinting == true)
        {
            throwForce = 80f;
        }
        else if (FindObjectOfType<PlayerMovement>().isSprinting == false)
        {
            throwForce = 60f;
        }
        pistolRB.AddForce(gunLocation.transform.forward * throwForce, ForceMode.Impulse);
        
    }
    
    public void ThrowDamageCalculator()
    {
        if (pistolRB.velocity.magnitude <= 15f)
        {
            throwDamage = 0f;
        }
        if(pistolRB.velocity.magnitude > 15f)
        {
            throwDamage = 120f;
        }

    }

    public void TeleportToGun()
    {

    }
}
