using UnityEngine;

[CreateAssetMenu(fileName = "DamageType", menuName = "Scriptable Objects/DamageType")]
public class DamageType : ScriptableObject
{
    public int damage;
    public int ticks = 0;
    public int delaySeconds = 0;
    public int subDamage = 0;
}
