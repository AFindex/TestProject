using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject objLoadFromAddressable;
    public string address1;
    public string address2;
    bool isLoaded = false;
    Image m_image;
    void Start()
    {
        m_image = GetComponent<Image>();
        isLoaded = false;
        //AsyncOperationHandle handler = Addressables.LoadAssetAsync<Sprite>(address);
        //Addressables.Release();
        Addressables.LoadAssetAsync<Sprite>(address1).Completed += OnHandleCompele;
        Addressables.LoadAssetAsync<GameObject>(address2).Completed += OnHandleCompeleGO;


        
       // StartCoroutine(loadTest(handler));
    }
    private void OnHandleCompeleGO(AsyncOperationHandle<GameObject> obj)
    {
        objLoadFromAddressable = obj.Result;
        objLoadFromAddressable.GetComponent<AClass>().LogSomething();
    }
    private void OnHandleCompele(AsyncOperationHandle<Sprite> obj)
    {
        m_image.sprite = obj.Result;
    }
    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("test");
        GUILayout.EndHorizontal();
    }
}
