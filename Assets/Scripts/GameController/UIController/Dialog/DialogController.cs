using UnityEngine;
using System.Collections;

public class DialogController : MonoBehaviour
{

    // Use this for initialization

    public enum ShowDialogType
    {
        FromLeft, FromTop, FromRight, FromBottom, Center
    }

    public enum CloseDialogType
    {
        ToLeft, ToTop, ToRight, ToBottom
    }

    public virtual void OnAwake() { }
    public virtual void OnStart() { }
    public virtual void OnUpdate() { }
    public System.Action onCloseComplete;
    [HideInInspector]
    public bool isAutoPlaySound = true;

    public bool isShowBannerAd = true;
    public enum BannerAdPosition
    {
        Top, Bottom
    }
    public BannerAdPosition bannerAdPosition = BannerAdPosition.Bottom;

    void Awake()
    {
        AssignObjects();
        OnAwake();
    }

    

    // Update is called once per frame
    void Update()
    {
        OnUpdate();
    }

    void OnDestroy()
    {
        CancelInvoke();
        StopAllCoroutines();
    }

    public virtual void AssignObjects()
    {

    }


    void Start()
    {
        if (isAutoPlaySound)
        {
            PlayShowHideSound();
        }

        OnStart();
    }

    public virtual void OnOpen(string[] agruments = null, System.Action onCloseComplete = null)
    {
        this.onCloseComplete = onCloseComplete;

    }

    public virtual void Close(System.Action onComplete = null)
    {
        PlayShowHideSound();
        System.Action tempOnComplete = null;

        if (onComplete != null)
        {
            tempOnComplete = onComplete;
        }

        else if (onCloseComplete != null)
        {
            tempOnComplete = onCloseComplete;

        }
        Master.UI.CloseDialog(gameObject, 0.4f, tempOnComplete);
    }

  

    public void PlayShowHideSound()
    {
        Master.Audio.PlaySound("snd_showHideDialog", 0.3f);
    }
    
    
    public virtual void OnShowComplete()
    {

    }

}
