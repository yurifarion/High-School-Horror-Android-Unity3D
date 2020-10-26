using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEditor;
using UnityEngine;

namespace GoogleMobileAds.Editor
{

    internal class GoogleMobileAdsSettings : ScriptableObject
    {
        private const string MobileAdsSettingsDir = "Assets/GoogleMobileAds";

        private const string MobileAdsSettingsResDir = "Assets/GoogleMobileAds/Resources";

        private const string MobileAdsSettingsFile =
            "Assets/GoogleMobileAds/Resources/GoogleMobileAdsSettings.asset";

        private static GoogleMobileAdsSettings instance;

        [SerializeField]
        private bool isAdManagerEnabled = false;

        [SerializeField]
        private bool isAdMobEnabled = false;

        [SerializeField]
        private string adMobAndroidAppId = "ca-app-pub-3940256099942544~3347511713";

        [SerializeField]
        private string adMobIOSAppId = "";

        [SerializeField]
        private bool delayAppMeasurementInit = false;

        public bool IsAdManagerEnabled
        {
            get
            {
                return Instance.isAdManagerEnabled;
            }

            set
            {
                Instance.isAdManagerEnabled = value;
            }
        }

        public bool IsAdMobEnabled
        {
            get
            {
                return Instance.isAdMobEnabled;
            }

            set
            {
                Instance.isAdMobEnabled = value;
            }
        }

        public string AdMobAndroidAppId
        {
            get
            {
                return Instance.adMobAndroidAppId;
            }

            set
            {
                Instance.adMobAndroidAppId = value;
            }
        }

        public string AdMobIOSAppId
        {
            get
            {
                return Instance.adMobIOSAppId;
            }

            set
            {
                Instance.adMobIOSAppId = value;
            }
        }

        public bool DelayAppMeasurementInit
        {
            get
            {
                return Instance.delayAppMeasurementInit;
            }

            set
            {
                Instance.delayAppMeasurementInit = value;
            }
        }

        public static GoogleMobileAdsSettings Instance
        {
            get
            {
                if (instance == null)
                {
                    if (!AssetDatabase.IsValidFolder(MobileAdsSettingsResDir))
                    {
                        AssetDatabase.CreateFolder(MobileAdsSettingsDir, "Resources");
                    }

                    instance = (GoogleMobileAdsSettings) AssetDatabase.LoadAssetAtPath(
                        MobileAdsSettingsFile, typeof(GoogleMobileAdsSettings));

                    if (instance == null)
                    {
                        instance = ScriptableObject.CreateInstance<GoogleMobileAdsSettings>();
                        AssetDatabase.CreateAsset(instance, MobileAdsSettingsFile);
                    }
                }
                return instance;
            }
        }

        internal void WriteSettingsToFile()
        {
            AssetDatabase.SaveAssets();
        }
    }
}
