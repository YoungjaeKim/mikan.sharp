using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Mikan
{
    public class Class1
    {

  string joshi = 
    "/(でなければ|について|かしら|くらい|けれど|なのか|ばかり|ながら|ことよ|こそ|こと|さえ|しか|した|たり|だけ|だに|だの|つつ|ても|てよ|でも|とも|から|など|なり|ので|のに|ほど|まで|もの|やら|より|って|で|と|な|に|ね|の|も|は|ば|へ|や|わ|を|か|が|さ|し|ぞ|て)/g";
  string keywords = "/(\\&nbsp;|[a-zA-Z0-9]+\\.[a-z]{2,}|[一-龠々〆ヵヶゝ]+|[ぁ-んゝ]+|[ァ-ヴー]+|[a-zA-Z0-9]+|[ａ-ｚＡ-Ｚ０-９]+)/g";
  string periods = "/([\\.\\,。、！\\!？\\?]+)$/g";
      private string bracketsBegin = "/([〈《「『｢（(\\[【〔〚〖〘❮❬❪❨(<{❲❰｛❴])/g";
      private string bracketsEnd = "/([〉》」』｣)）\\]】〕〗〙〛}>\\)❩❫❭❯❱❳❵｝])/g";


  string SimpleAnalyze(string str) {
    var words = str.Split(keywords).reduce(function(prev, word) {
      return [].concat(prev, word.Split(joshi));
    }).reduce(function(prev, word) {
      return [].concat(prev, word.Split(bracketsBegin));
    }).reduce(function(prev, word) {
      return [].concat(prev, word.Split(bracketsEnd));
    }).filter(function(word) {
      return word;
    });


    var result = new List<string>();
    var prevType = "";
    var prevWord = "";
    for (int i = 0; i < words.Length; i++)
    {
      var word = words[i];
      var token = word.match(periods) || word.match(joshi);

      if (word.match(bracketsBegin)) {
        prevType = "bracketBegin";
        prevWord = word;
        return string.Empty;
      }
      if (word.match(bracketsEnd)) {
        result[result.Count - 1] += word;
        prevType = "bracketEnd";
        prevWord = word;
        return string.Empty;
      }

      if (prevType == "bracketBegin")
      {
        word = prevWord + word;
        prevWord = "";
        prevType = "";
      }

      // すでに文字が入っている上で助詞が続く場合は結合する
      if (result.Count > 0 && token && prevType == "") {
        result[result.Count - 1] += word;
        prevType = "keyword";
        prevWord = word;
        return string.Empty;
      }

      // 単語のあとの文字がひらがななら結合する
      if (result.Count > 1 && token || (prevType == "keyword" && Regex.IsMatch(word, "/[ぁ-んゝ]+/g"))) {
        result[result.Count - 1] += word;
        prevType = "";
        prevWord = word;
        return string.Empty;
      }
      result.Add(word);
      prevType = "keyword";
      prevWord = word;      
    }

    return result.Join();
  }
    
    
}