using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPVisual : MonoBehaviour
{
    public static HPSystem hpSystemStatic;

    [SerializeField] private Sprite hp0Sprite;
    [SerializeField] private Sprite hp1Sprite;
    [SerializeField] private Sprite hp2Sprite;
    [SerializeField] private Sprite hp3Sprite;
    [SerializeField] private Sprite hp4Sprite;

    private List<HPImage> hpImageList;
    private HPSystem hpSystem;

    private void Awake()
    {
        hpImageList = new List<HPImage>();        
    }

    private void Start()
    {
        HPSystem hpSystem = new HPSystem(1);
        SetHPSystem(hpSystem);
    }

    public void SetHPSystem(HPSystem hpSystem)
    {
        this.hpSystem = hpSystem;
        hpSystemStatic = hpSystem;

        List<HPSystem.HP> hpList = hpSystem.GetHPList();
        Vector2 hpAnchoredPosition = new Vector2(0, 0);
        for (int i = 0; i < hpList.Count; i++)
        {
            HPSystem.HP hp = hpList[i];
            CreateHPImage(hpAnchoredPosition).SetHPFragments(hp.GetFragmentAmount());
            hpAnchoredPosition += new Vector2(30, 0);
        }

        hpSystem.OnDamaged += HPSystem_OnDamaged;
        //hpSystem.OnDead += HPSystem_OnDead;
    }

    /*private void HPSystem_OnDead(object sender, System.EventArgs e)
    {
        isDead = true;
    }*/

    private void HPSystem_OnDamaged(object sender, System.EventArgs e)
    {
        List<HPSystem.HP> hpList = hpSystem.GetHPList();
        for (int i = 0; i < hpImageList.Count; i++)
        {
            HPImage hpImage = hpImageList[i];
            HPSystem.HP hp = hpList[i];
            hpImage.SetHPFragments(hp.GetFragmentAmount());
        }
    }

    private HPImage CreateHPImage(Vector2 anchoredPosition)
    {
        GameObject hpGameObject = new GameObject("HP", typeof(Image));
        
        hpGameObject.transform.parent = transform;
        hpGameObject.transform.localPosition = Vector3.zero;

        hpGameObject.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
        hpGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(110, 110);

        Image hpImageUI = hpGameObject.GetComponent<Image>();
        hpImageUI.sprite = hp4Sprite;


        HPImage hpImage = new HPImage(this, hpImageUI);
        hpImageList.Add(hpImage);

        return hpImage;
    }

    //Изображает одно хп
    public class HPImage
    {
        private Image hpImage;
        private HPVisual hpVisual;

        public HPImage(HPVisual hpVisual, Image hpImage)
        {
            this.hpVisual = hpVisual;
            this.hpImage = hpImage;
        }

        public void SetHPFragments(int fragments)
        {
            switch (fragments)
            {
                case 0: hpImage.sprite = hpVisual.hp0Sprite; break;
                case 1: hpImage.sprite = hpVisual.hp1Sprite; break;
                case 2: hpImage.sprite = hpVisual.hp2Sprite; break;
                case 3: hpImage.sprite = hpVisual.hp3Sprite; break;
                case 4: hpImage.sprite = hpVisual.hp4Sprite; break;
            }
        }
    }
}
