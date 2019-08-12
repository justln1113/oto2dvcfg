# oto2dvcfg
 A program for UTAU oto config to DeepVocal dvcfg config conversion.  
一支可以把UTAU音源設定檔轉成DeepVocal音源設定檔的程式。  
[最新版本(latest version)](https://github.com/justln1113/oto2dvcfg/releases/download/Beta_V0.3/oto2dvcfg_Beta_V0.3.zip)

**目錄 - Table of Contents**
* [中文](#中文)
  * [使用教學](#使用教學)
    * [前置準備](#前置準備)
    * [進入正題]()
    * [後續修正]()
    * [注意事項]()
   * [開發教學]()
     * issues
     * 其他
* [English](#English)
  * [User's guide](#User-guide)
## 中文
### 使用教學
#### 前置準備
請先將欲轉換之音源複製出來，雖然可以在要生成的時候選擇資料夾，但還是建議(目前必須)確保音源所有(單音階音色)wav檔和oto.ini在同一個資料夾下。  
![image](https://github.com/justln1113/oto2dvcfg/blob/master/Resource/wav_and_oto_in_same_dir.png)  
然後打開有尋找與取代功能的文字編輯器~~要用windows記事本也是可以~~打開oto.ini，並刪除不需要的設定，
如長音(_L)、純子音......等等  
因為尾綴自動取代功能尚未完成，所以目前必須手動用"尋找與取代"功能刪掉它，例如：尋找`_A3`並取代成`(不輸入任何字元)`。



## English
### User guide
#### Preparation
Please copy out your voicebank first. 
Although you can select the folder when you want to generate config file, 
But ensure that all the wav file and oto.ini are under the same folder is recrecommended.
![image](https://github.com/justln1113/oto2dvcfg/blob/master/Resource/wav_and_oto_in_same_dir.png)  
Then open the oto.ini in a text editor with the find and replace function. delete unused alias like consonant only alias`-p, -k, etc...`
or long note`vowel_L` etc...   
Because suffix replacement fuction is not complete, so you need to remove those manually via find and replace in your text editor.  
e.g. find `_A3`, and replace with `(don't input anything)`
