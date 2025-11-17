using UnityEngine;

[CreateAssetMenu(fileName = "DamageType", menuName = "Scriptable Objects/DamageType")]
public class DamageType : ScriptableObject
{
    public int damage;
    public int ticks;
    public int delaySeconds;
    public int subDamage;
}
