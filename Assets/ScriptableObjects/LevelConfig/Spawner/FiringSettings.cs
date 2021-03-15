using UnityEngine;

[CreateAssetMenu(fileName = "FiringSettings", menuName = "Spawner/FiringSettings")]
public class FiringSettings : ScriptableObject
{
    [SerializeField] public FiringSequence firingSequence;

    [Range(0.0f, 10.0f)]
    [SerializeField] public float fireRate = 0.5f;

    [Range(0.0f, 10.0f)]
    [SerializeField] public float projectileSpeed = 1f;

    [Range(-1.0f, 1.0f)]
    [SerializeField] public float projectileSpin = 0.0f;

}
public enum FiringSequence
{
    Random,
    Sequential,
    ReverseSequential,
    SineWave,
    CosWave,
}

