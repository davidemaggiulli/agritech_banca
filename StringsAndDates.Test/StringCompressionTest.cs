using System;
using Xunit;

namespace StringsAndDates.Test
{
    public class StringCompressionTest
    {
        [Fact]
        public void Test1()
        {
            //kkkktttrrrrrrrrrr --> k4t3r10
            StringCompress sc = new StringCompress();
            string input = "kkkktttrrrrrrrrrr";
            string output = sc.Compress(input);

            Assert.Equal("k4t3r10", output);
        }

        [Fact]
        public void Test2()
        {
            //aaaabbbfbbfbfbfda --> a4b3f1b2f1b1f1b1f1d1a1
            StringCompress sc = new StringCompress();
            string input = "aaaabbbfbbfbfbfda";
            string output = sc.Compress(input);

            Assert.Equal("a4b3f1b2f1b1f1b1f1d1a1", output);

            
        }

        [Fact]
        public void Test3()
        {
            //aaaabbbfbbfbfbfda --> a4b3f1b2f1b1f1b1f1b1d1a1
            StringCompress sc = new StringCompress();
            string input = "";
            string output = sc.Compress(input);

            Assert.Equal("", output);
        }

        [Fact]
        public void Test4()
        {
            //aaaabbbfbbfbfbfda --> a4b3f1b2f1b1f1b1f1b1d1a1
            StringCompress sc = new StringCompress();
            string input = null;

            Assert.Throws<ArgumentNullException>(() => sc.Compress(input));
        }

        [Fact]
        public void Test5()
        {
            //aabbccc --> a2b2c3
            StringCompress sc = new StringCompress();
            string input = "aabbccc";
            string output = sc.Compress(input);

            Assert.Equal("a2b2c3", output);
        }

        [Fact]
        public void Test6()
        {
            //aabbcccdaaa --> a2b2c3d1a3
            StringCompress sc = new StringCompress();
            string input = "aabbcccdaaa";
            string output = sc.Compress(input);

            Assert.Equal("a2b2c3d1a3", output);
        }
    }
}
