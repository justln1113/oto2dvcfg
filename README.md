# oto2dvcfg
 A program for UTAU oto config to DeepVocal dvcfg config conversion.  
一支可以把UTAU音源設定檔轉成DeepVocal音源設定檔的程式。  
[最新版本(latest version)](https://github.com/justln1113/oto2dvcfg/releases/download/Beta_V1.3.1/oto2dvcfg_Beta_V1.3.1.zip)

**目錄 - Table of Contents**
* [中文](#中文)
  * [使用教學](#使用教學)
    * [前置準備](#前置準備)
    * [開始轉換](#開始轉換)
    * [後續修正](#後續修正)
    * [注意事項]()
   * [開發教學]()
     * issues
     * 其他
* [English](#English)
  * [User's guide](#User-guide)
    * [Preparation](#Preparation)
    * [Start convertion](#Start-convertion)
## 中文

### 使用教學

#### 前置準備

請確保音源所有(單音階或單音色)wav檔和oto.ini在同一個資料夾下，且輸出的voice.dvcfg檔案也必須在同一個資料夾(因為voice.dvcfg的位置對應到了DeepVocal ToolBox的wav location)。  
請勿直接轉換```Program files(x86)\UTAU\Voice```資料夾下的音源，避免權限錯誤。   
![image](https://github.com/justln1113/oto2dvcfg/blob/master/Resource/wav_and_oto_in_same_dir.png)   
>**提示**：可先刪除掉frq等引擎產生的週波數表

#### 開始轉換

>程式主畫面  

![image](https://github.com/justln1113/oto2dvcfg/blob/master/Resource/oto2dvcfg_main_form.png)  

按下加號按鈕開啟oto.ini  
![image](https://github.com/justln1113/oto2dvcfg/blob/master/Resource/add_button.png)  

這裡使用```句音コノ。弱CVVC```A3音階的oto作為範例  
![image](https://github.com/justln1113/oto2dvcfg/blob/master/Resource/oto_opened.png)  

##### 列表編輯  
選取後按右鍵可呼叫選單，有刪除和轉換格式等功能，這裡使用Delete select settings來刪除不必要的設定(也可直接按下鍵盤上的Delete按鍵)  
![image](https://github.com/justln1113/oto2dvcfg/blob/master/Resource/right_click_menu.png)  

##### 尋找與取代  
此功能可以透過新增```取代規則```對設定名稱(alias)進行尋找與取代，可利用此功能代換文字或移除掉前綴後綴等。  
>**注意**：目前此功能有尚未解決的bug，新增取代規則時一定要輸入名稱，否則無法取代。  
>**提示**：不同順序會有不同效果喔，程式進行取代的順序為由上往下，請注意新增規則的順序。  

![image](https://github.com/justln1113/oto2dvcfg/blob/master/Resource/Find_and_replace.png)  

##### 假名轉羅馬拼音
可用此功能將oto內帶假名的設定名稱轉換成羅馬拼音，在DeepVocal設定上會較為方便。  
轉換器提供了兩種方案如下：
- ```n to N```：將元音```ん```轉換為拼音```N```  
- ```consonant n to n'```：將連接音中的子音```n```(VC，如```a_na.....ra.wav```錄音的```a n```)轉換為```n'```(如```a n'```)  

![image](https://github.com/justln1113/oto2dvcfg/blob/master/Resource/Two_hira2roma.png)

##### 音高定義
因為目前程式並無自動偵測前後綴來定義音高的功能，因此無論先前是否有移除前後綴，在生成dvcfg前請記得在Pitch文字框中輸入音高  
![image](https://github.com/justln1113/oto2dvcfg/blob/master/Resource/Pitch_def.png)

##### 輸出檔案
按下Generate!!之後，會出現預覽視窗，確認基本內容無誤後即可按下Save保存  
>**注意**：若要讓DeepVocal toolbox讀取，請將檔案命名為```voice.dvcfg```，並且請將voice.dvcfg與wav檔案放在同一個資料夾   

![image](https://github.com/justln1113/oto2dvcfg/blob/master/Resource/formPreview.png)  

#### 後續修正


## English

### User Guide

#### Preparation 

Ensure that all the wav files and oto.ini are under the same folder.
Don't direct convert voice bank under ```Program files(x86)\UTAU\Voice``` to avoid permission errors.  
![image](https://github.com/justln1113/oto2dvcfg/blob/master/Resource/wav_and_oto_in_same_dir.png)  

#### Start Convertion  

Program screenshot  
![image](https://github.com/justln1113/oto2dvcfg/blob/master/Resource/oto2dvcfg_main_form.png)  

Press the add button to open oto.ini file  
![image](https://github.com/justln1113/oto2dvcfg/blob/master/Resource/add_button.png)

Here we take ```Kuon kono。raku-CVVC (句音コノ。弱CVVC)``` oto on A3 for example.  
![image](https://github.com/justln1113/oto2dvcfg/blob/master/Resource/oto_opened.png)  

##### List Edit
After picked and clicked right mouse botton, it can call the menu which has delete, form transform functions, etc. Here we used "Delete select settings" to remove unimportant settings.
(You can also press the delete button on keyboard instead)  
![image](https://github.com/justln1113/oto2dvcfg/blob/master/Resource/right_click_menu.png)  

##### Find and Replace
Let alias can be replaced, removed prefixes or suffixes functions, ect., via adding ```Find and Replace rules```.  
>**Mention**：This function has an unsloved bug, which must enter rule name, or it can't be replaced.  
>**Hint**：Different orders have different results. The order of replacing is from top to bottom, please notice this when you adding rules.  
![image](https://github.com/justln1113/oto2dvcfg/blob/master/Resource/Find_and_Replace.png)  

##### Hiragana to Romaji
Let oto which have Hiragana setting alias can be transformed to Romaji. It can be helped when using DeepVocal settings.  
Converter has two plans：
- ```n to N```: Convert vowel ```ん``` into ```N```.  
- ```Consonant n to n'```: Convert consonant ```n``` in VC part into ```n'```. (e.g. Convert ```a n``` alias in```a_na_ha_ma_ba_pa_ra.wav``` into  ```a n'```)   

![image](https://github.com/justln1113/oto2dvcfg/blob/master/Resource/Two_hira2roma.png)

##### Pitch definition
Because this program can't detect prefixes or suffixes to definite the pitch automatically, before you start to create dvcfg, please enter pitch in the Pitch textbox no matter if you removed suffixes  
![image](https://github.com/justln1113/oto2dvcfg/blob/master/Resource/Pitch_def.png)

##### Output dvcfg
It will appear a preview screen after clicked "Generate!!" botton. Click "Save" botton to save files if you ensure the content is correct.  
>**Mention**：If you want to let DeepVocal toolbox can read your files, please name your file  ```voice.dvcfg```, and put your ```voice.dvcfg``` in same folder with wav files.  

![image](https://github.com/justln1113/oto2dvcfg/blob/master/Resource/formPreview.png)  
