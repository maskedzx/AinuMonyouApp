using UnityEngine;
using System.Collections;
using SWorker;

public class snsTest : MonoBehaviour {
    string message = "test";
    string url = "test";
    string imagePath = "/storage/emulated/0/Android/data/com.ainumonyou.product/files/screenshot.png";


	

	public void testSns () {
        SocialWorker.PostTwitter(message, url, imagePath);
	}
}
