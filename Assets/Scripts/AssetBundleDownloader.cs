using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class AssetBundleDownloader : MonoBehaviour
{
    // GitHub의 Raw URL 주소를 입력하세요
    string bundleURL = "https://raw.githubusercontent.com/eom-devlog/AssetBundle/main/Repository/test.test";

    void Start()
    {
        StartCoroutine(DownloadAndLoadBundle());
    }

    IEnumerator DownloadAndLoadBundle()
    {
        // 1. 웹 요청 생성
        using (UnityWebRequest webRequest = UnityWebRequestAssetBundle.GetAssetBundle(bundleURL))
        {
            // 2. 전송 및 대기
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("다운로드 에러: " + webRequest.error);
            }
            else
            {
                // 3. 다운로드된 번들 가져오기
                AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(webRequest);

                if (bundle != null)
                {
                    Debug.Log("서버에서 번들 로드 성공!");

                    
                    //아까 저장한 프리펩정보
                    GameObject prefab = bundle.LoadAsset<GameObject>("Capsule1");
                    Instantiate(prefab);

                    prefab = bundle.LoadAsset<GameObject>("Capsule2");
                    Instantiate(prefab);

                    prefab = bundle.LoadAsset<GameObject>("Capsule3");
                    Instantiate(prefab);

                    // 4. 메모리 해제
                    bundle.Unload(false);
                }
            }
        }
    }
}
