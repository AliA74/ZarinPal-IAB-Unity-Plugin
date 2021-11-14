# ZarinPal In App Billing - Purchase SDK - Unity Plugin

This package provides the functionality of Payment through ZarinPal in Unity on Android

## Introduction

ZarinPal in-app purchases are the simplest solution to selling digital products or content on Android apps. So many app developers who want to sell digital goods or offer premium membership to users can simply use the it, in-app billing process for smooth and easy checkouts.

## Requirements

- Unity 2019.3 Or Later
- Android Target Platform installed for Unity

## Installation

You can install package either directly from Unity's Package Manager by git Url or by downloading this repo and Putting it under Packages folder of your project.

**By Git Url**

Open *Package Manager* ( Window -> Package Manager ). In Package Manager window click on the top-left button with + icon, choose *add package from git URL...* , enter or copy the following link ( `https://github.com/AliA74/ZarinPal-IAB-Unity-Plugin.git` )

![Adding package in Package Manager using Git URL](.github~/tut_1.jpg "Adding package in Package Manager using Git URL")

**Embedding in the project**

If you don't want to use the previous method for installing the package, You can do the following:

1. create a folder titled `com.zarinpal.iab` under Packages folder inside the root folder of your project.
2. clone/download this repository and put all the content inside the folder you created at previous step (`com.zarinpal.iab`)


## Setup

This package requires some setup before it can be used correctly on Android. Make sure active build target is Android in Unity before continuing.

#### Step 1

Open **Player Settings** (Edit -> Project Settings -> Player). Select *Android Settings* then select *Publishing Settings*. Check both **Custom Main Gradle Template** and **Custom Gradle Properties Template**

![Player Settngs for Android](.github~/tut_2.jpg)

#### Step 2

Open the file `Assets/Plugins/Android/mainTemplate.gradle` by a text editor. Add the following line to the **dependencies** section:

<code>

    implementation 'com.zarinpal:payment-provider:0.5.2'
</code>
  
    

**(Optional)** If your project and business is trusted to ZarinPal, SDK is able to provide Mobile Payment Gateway on your App so you can add the MPG dependency:
<code>

    implementation 'com.zarinpal:mpg:0.5.2'
</code>

**Note.** You can change the version of the ZarinPal SDK inside the dependencies you just added. At the time of writing this document the latest version is `0.5.2`. You can check for newer versons here: https://github.com/ZarinPal/Android-SDK/releases
  


#### Step 3

Open the file `Assets/Plugins/Android/gradleTemplate.properties` by a text editor. Add the following lines to it if not already present:

<code>
    
    android.useAndroidX=true
    android.enableJetifier=true
</code>

#### Step 4

Set Minimum Android API Level to `Android 5.0 (API Level 21)`.

You can find this setting inside Android Player Settings (which we visited in Step-1) and in **Other Settings**.

![](.github~/tut_3.jpg)

#### Step 5 (Optional)

If your eligible to have payment process through **MPG** and willing to use **MPG**, add `usesCleartextTraffic` to application tag in your `Assets/Plugins/Android/AndroidManifest.xml` :

<code>

    <application
            android:name="..."
            android:usesCleartextTraffic="true"
            ....
            \>
</code>

  

## Usage

To use the ZarinPal API inside your scripts add a using directive at the top of your script:
<code>
    
    using Zarinpal;
</code>

**Hint.** If `Zarinpal` is not recognized you may have to add `ZarinPalAssembly` to your Scripts Assembly Definition.

### Initialization

You have to call `ZarinpalIAB.Init()` at first before calling any other method on `ZarinpalIAB`.
Example:
<code>

    void Start()
    {
        ZarinpalIAB.Init(showInvoice: true);
    }
</code>

### Make Purchase

You can use following three static methods to make purchase:
<code>

    ZarinpalIAB.PurchaseBySKU(string SkuID)

    ZarinpalIAB.PurchaseByPaymentRequest(string merchantId, long amountInToman, string callbackURL, string description,string mobileNumber = null, string email = null)

    ZarinpalIAB.PurchaseByAuthority(string Authority)
</code>

### Query Purchased Sku(s)

You can use following three static methods to query purchased sku(s):
<code>

    ZarinpalIAB.QueryPurchasedSkusByMobile(string merchantId, string mobileNumber,string[] skuList)

    ZarinpalIAB.QueryPurchasedSkusByEmail(string merchantId, string email, string[] skuList)

    ZarinpalIAB.QueryPurchasedSkusCardPan(string merchantId, string cardPan, string[] skuList)
</code>


### Events

You can subscribe to the following events to get notified from purchase results and query results.

<code>
    
    ZarinpalIAB.OnPurchase

    ZarinpalIAB.OnQuery

    ZarinpalIAB.OnQueryError
</code>