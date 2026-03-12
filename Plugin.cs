using BepInEx;
using HarmonyLib;
using UnityEngine;

[BepInPlugin("com.potpot.flyingv1", "Flying V1", "1.0.0")]
public class GabrielPlugin : BaseUnityPlugin
{
    void Awake()
    {
        var harmony = new Harmony("com.potpot.flyingv1");
        harmony.PatchAll();
        Logger.LogInfo("Flying V1: 75 MPH Sprint & 69 DMG Direct Hit Ready!");
    }
}

[HarmonyPatch(typeof(NewMovement), "Start")]
public class PlayerPatch
{
    static void Postfix(NewMovement __instance)
    {
        if (__instance.gameObject.GetComponent<GabrielController>() == null)
        {
            __instance.gameObject.AddComponent<GabrielController>();
        }
    }
}

public class GabrielController : MonoBehaviour
{
    private NewMovement nm;
    private Rigidbody rb;
    private float flightSpeed = 30f;
    private float sprintSpeed = 75f; // Hits that 75.000 MPH mark
    private bool isFlying = false;
    private float lastSpaceTime = 0f;
    private float lastWTime = 0f;
    private bool isSprinting = false;

    void Start()
    {
        nm = GetComponent<NewMovement>();
        rb = GetComponent<Rigidbody>();
        if (rb != null) rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
    }

    void Update()
    {
        if (nm != null) nm.boostCharge = 300f;

        // 1. SPACE TOGGLE (TAKE OFF)
        if (UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.Space))
        {
            float timeSinceLastTap = UnityEngine.Time.time - lastSpaceTime;
            if (timeSinceLastTap < 0.3f && !isFlying)
            {
                isFlying = true; 
                rb.useGravity = false;
                rb.velocity = UnityEngine.Vector3.zero;
                SpawnSFX("Prefabs/Attacks/Explosions/Explosion");
            }
            lastSpaceTime = UnityEngine.Time.time;
        }

        // 2. W DOUBLE-TAP (SPRINT)
        if (UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.W))
        {
            if (UnityEngine.Time.time - lastWTime < 0.3f) isSprinting = true;
            lastWTime = UnityEngine.Time.time;
        }
        if (UnityEngine.Input.GetKeyUp(UnityEngine.KeyCode.W)) isSprinting = false;

        // 3. LAND (Left Control)
        if (UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.LeftControl) && isFlying)
        {
            isFlying = false;
            rb.useGravity = true;
            SpawnSFX("Prefabs/Attacks/Explosions/ExplosionSuper");
        }

        // 4. MOVEMENT CONTROLS
        if (isFlying)
        {
            float h = UnityEngine.Input.GetAxisRaw("Horizontal");
            float v = UnityEngine.Input.GetAxisRaw("Vertical");
            
            // Space to fly Up, Z to fly Down
            float y = 0;
            if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.Space)) y = 1;
            else if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.Z)) y = -1;

            if (UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.LeftShift))
            {
                rb.velocity = transform.forward * 55f; // 1.9x Dash
                SpawnSFX("Prefabs/Attacks/Insurrectionist/InsurrectionistJump");
            }
            else
            {
                float currentSpeed = isSprinting ? sprintSpeed : flightSpeed;
                UnityEngine.Vector3 moveDir = (transform.right * h) + (transform.forward * v) + (UnityEngine.Vector3.up * y);
                rb.velocity = moveDir.normalized * currentSpeed;
            }
        }
    }

    private void SpawnSFX(string path)
    {
        GameObject prefab = Resources.Load<GameObject>(path);
        if (prefab != null) Instantiate(prefab, transform.position, UnityEngine.Quaternion.identity);
    }

    void OnCollisionEnter(Collision col)
    {
        if (isFlying && isSprinting && col.gameObject.layer != 20)
        {
            // 5. DIRECT ENEMY IMPACT (69 DMG / 0 DMG TO PLAYER)
            EnemyIdentifier eid = col.gameObject.GetComponentInParent<EnemyIdentifier>();
            if (eid != null)
            {
                // Deliver 69 damage to enemy, 0 to player
                eid.DeliverDamage(col.gameObject, transform.forward * 10f, col.GetContact(0).point, 69f, false);
                SpawnSFX("Prefabs/Attacks/Explosions/Explosion");
                return;
            }

            // 6. WALL IMPACT (50 DMG EXPLOSION)
            GameObject expPrefab = Resources.Load<GameObject>("Prefabs/Attacks/Explosions/Explosion");
            if (expPrefab != null)
            {
                GameObject e = Instantiate(expPrefab, col.GetContact(0).point, UnityEngine.Quaternion.identity);
                Explosion exp = e.GetComponentInChildren<Explosion>();
                if (exp != null)
                {
                    exp.damage = 50;
                    exp.maxSize = 15f;
                }
            }
            if (MonoSingleton<CameraController>.Instance != null)
                MonoSingleton<CameraController>.Instance.CameraShake(0.7f);
        }
    }
}
