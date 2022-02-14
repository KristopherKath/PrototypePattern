using UnityEditor;
using System.IO;
using UnityEngine;

[CustomEditor (typeof(AsteroidSpawner))]
public class AsteroidSpawnerEditor : Editor
{
    string path;
    string assetpath;
    string filename;

    private void OnEnable()
    {
        path = Application.dataPath + "/Asteroid";
        assetpath = "Assets/Asteroid/";
        filename = "asteroid_" + System.DateTime.Now.Ticks.ToString();
    }

    public override void OnInspectorGUI()
    {
        AsteroidSpawner asteroidSpawner = (AsteroidSpawner)target; //grabe the asteroid spawner inspector target
        DrawDefaultInspector(); //displays default values that would be shown

        if (GUILayout.Button("Create Asteroid"))
            asteroidSpawner.CreateAsteroid();
        if (GUILayout.Button("Save Asteroid")) 
        { 
            System.IO.Directory.CreateDirectory(path);
            Mesh mesh = asteroidSpawner.asteroid.GetComponent<MeshFilter>().sharedMesh;
            AssetDatabase.CreateAsset(mesh, assetpath + mesh.name + ".asset");
            AssetDatabase.SaveAssets();

            PrefabUtility.SaveAsPrefabAsset(asteroidSpawner.asteroid, assetpath + filename + ".prefab");
        }
    }
}
