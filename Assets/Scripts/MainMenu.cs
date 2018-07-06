using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public GameObject ButtonPrefab;
    public GameObject ButtonsContainer;

    public GameObject ThemeTexturePrefab;
    public GameObject ThemeTexturesContainer;

    public Material PlayerMaterial;

    public float cameraLookAtSpeed = 3.0f;

    private Transform TargetTrans;


	// Use this for initialization
	void Start () {

        ChangePlayerSkin(0);

        Sprite[] sprites = Resources.LoadAll<Sprite>("Levels");
        foreach( Sprite sp in sprites)
        {
            GameObject button = Object.Instantiate(ButtonPrefab) as GameObject;
            button.GetComponent<Image>().sprite = sp;
            button.transform.SetParent(ButtonsContainer.transform, false);

            string sceneName = sp.name;

            button.GetComponent<Button>().onClick.AddListener(() => LoadLevel(sceneName));

        }

        Sprite[] textures = Resources.LoadAll<Sprite>("Player");

        int textureIndex = 0;
        foreach( Sprite texture in textures)
        {
            GameObject button = Object.Instantiate(ThemeTexturePrefab) as GameObject;
            button.GetComponent<Image>().sprite = texture;
            button.transform.SetParent(ThemeTexturesContainer.transform, false);

            int index = textureIndex;
            button.GetComponent<Button>().onClick.AddListener(() => ChangePlayerSkin(index) );
            textureIndex++;
        }


    }
	
	// Update is called once per frame
	void Update () {

        if( TargetTrans )
        {
            Camera.main.transform.rotation = Quaternion.Slerp(Camera.main.transform.rotation, TargetTrans.rotation, cameraLookAtSpeed * Time.deltaTime);
        }
        
	}

    public void LookAtMenu( Transform TargetTransform)
    {
        TargetTrans = TargetTransform;
        //Camera.main.transform.LookAt(TargetTransform.position);
    }

    private void LoadLevel( string name )
    {
        Debug.Log("Load Level: " + name); //test
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);

    }

    private void ChangePlayerSkin( int index)
    {
        float x = (index % 4) * 0.25f;
        float y = (index / 4) * 0.25f;
        PlayerMaterial.SetTextureOffset("_MainTex", new Vector2(x, y));
    }
}
