using UnityEngine;

[CreateAssetMenu(fileName = "Bullet", menuName = "Scriptable Objects/Bullet")]
public class Bullet : ScriptableObject
{
    public int damage = 5;
    public GameObject particleFXPrefab;
    public Color color;
    public string element;
    public GameObject impactObject;
}
