using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    private BackBtnManager BBM;

    public Image[] panelList;
    public Button backBtn;
    private Dictionary<string, int> imageList = new Dictionary<string, int>();
    public GameObject parent;

    private int temp;
    private GameObject tempImgObj;
    private GameObject tempBtnObj;
    private Image tempImage;
    private Button tempBtn;

    private bool isPanelPopup = false;

    private void Start()
    {
        BBM = GameObject.Find("BtnManager").GetComponent<BackBtnManager>();

        imageList.Add("Wolf", 0);
        imageList.Add("Geralt", 1);
        imageList.Add("Triss", 2);
        imageList.Add("Yennefer", 3);
        imageList.Add("Token", 4);
    }

    public void createImagePopup(string name)
    {
        if (!isPanelPopup)
        {
            temp = imageList[name];

            tempImage = Instantiate(panelList[temp]);
            tempImage.transform.SetParent(parent.transform);
            tempImage.transform.localPosition = new Vector3(0, 0, 0);

            tempBtn = Instantiate(backBtn);
            tempBtn.transform.SetParent(parent.transform);
            tempBtn.transform.localPosition = new Vector3(0.5f, -255, 0);
        }

        isPanelPopup = true;
    }

    public void destroyPanelObj()
    {
        Destroy(tempImage.gameObject);
        Destroy(tempBtn.gameObject);

        isPanelPopup = false;
    }
}
