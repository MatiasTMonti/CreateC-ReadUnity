using UnityEngine;
using System.IO;
using System;

public class ReadFile : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private int posX = 0;
    private int posY = 0;

    // Start is called before the first frame update
    void Start()
    {
        ReadFileMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadFileMap()
    {
        FileStream fs = File.OpenRead("Assets/Map/example.dat");

        BinaryReader br = new BinaryReader(fs);

        posX = br.ReadInt32();
        posY = br.ReadInt32();
        player.transform.position = new Vector2(posX, posY);

        br.Close();
        fs.Close();
    }
}
