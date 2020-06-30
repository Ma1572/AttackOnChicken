using UnityEngine;

public class PresetSpawner : MonoBehaviour
{
    private AutoSpawn_Dynamic _worldSpawner;
    private MoveUp _player;
#pragma warning disable 0649 
    [SerializeField] private int initialPresetSize;
#pragma warning restore 0649 

    private void Start()
    {
        _worldSpawner = GetComponent<AutoSpawn_Dynamic>();
        _player = FindObjectOfType<MoveUp>();

        for (int i = 0; i <= initialPresetSize; i++)
        {
            _worldSpawner.UseObject();
            _player.UpdateNext();
        }
    }
}
