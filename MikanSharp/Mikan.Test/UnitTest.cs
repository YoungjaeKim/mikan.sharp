using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mikan.Test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Test1()
        {
            var source = "常に最新、最高のモバイル。Androidを開発した同じチームから。";
            var expected = new List<string>()
            {
                 "常に", "最新、", "最高の", "モバイル。", "Androidを", "開発した", "同じ", "チームから。"
            };
            var result = Mikan.Split(source);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test2()
        {
            var source = "原稿と防災服を用意してくれ";
            var expected = new List<string>()
            {
                 "原稿と", "防災服を", "用意してくれ"
            };
            var result = Mikan.Split(source);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test3()
        {
            var source = "1192";
            var expected = new List<string>()
            {
                 "1192"
            };
            var result = Mikan.Split(source);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test4()
        {
            var source = "やりたいことのそばにいる";
            var expected = new List<string>()
            {
                "やりたいことの", "そばに", "いる"
            };
            var result = Mikan.Split(source);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test5()
        {
            var source = "このmikan.jsというライブラリは、スマートな文字区切りを可能にします。";
            var expected = new List<string>()
            {
                 "この", "mikan.jsと", "いう", "ライブラリは、", "スマートな", "文字区切りを", "可能にします。"
            };
            var result = Mikan.Split(source);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test6()
        {
            var source = "「あれ」でもない、「これ」でもない。";
            var expected = new List<string>()
            {
                 "「あれ」", "でもない、", "「これ」", "でもない。"
            };
            var result = Mikan.Split(source);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test7()
        {
            var source = "半角スペース 対応";
            var expected = new List<string>()
            {
                 "半角", "スペース", " ", "対応"
            };
            var result = Mikan.Split(source);
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
