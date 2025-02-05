﻿using System;
using System.Linq;
using System.Threading.Tasks;
using BitlyAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BitlyTestV4
{
    [TestClass]
    public class BitlyTestV4
    {
        //Get from https://bitly.is/accesstoken
        private static readonly string _genericAccessToken = "";

        [TestMethod]
        public void GetGroups()
        {
            var bitly = new Bitly(_genericAccessToken);
            Assert.IsNotNull(bitly);

            var groups = bitly.GetGroups().Result;
            Assert.IsTrue(groups.Any());
        }


        [TestMethod]
        public async Task PostShorten()
        {
            var bitly = new Bitly(_genericAccessToken);
            Assert.IsNotNull(bitly);

            var linkResponse = await bitly.PostShorten("https://www.google.ca/");
            Assert.AreEqual("https://s.phansoft.ca/1WuTssO", linkResponse.Link);
            Assert.AreEqual("https://www.google.ca/", linkResponse.LongUrl);
        }

        [TestMethod]
        public async Task GetBitlinksByGroup()
        {
            var bitly = new Bitly(_genericAccessToken);
            Assert.IsNotNull(bitly);

            var firstPage = await bitly.GetBitlinksByGroup();
            Assert.IsTrue(firstPage.Links.Any());
        }

        [TestMethod]
        public async Task GetMetrics()
        {
            var bitly = new Bitly(_genericAccessToken);
            Assert.IsNotNull(bitly);

            var now = DateTime.Now;
            var testUrl = "https://www.google.ca/?q=" + now.ToShortDateString() + now.ToLongTimeString();
            var linkResponse = await bitly.PostShorten(testUrl);

            //Bitly won't show links that are very new
            await Task.Delay(TimeSpan.FromSeconds(30));

            var newest = await bitly.GetBitlinksByGroup(createdAfter: now);
            Assert.IsTrue(newest.Links.Any(l => l.LongUrl == testUrl));

            var newestLink = newest.Links.FirstOrDefault();
            Assert.IsNotNull(newestLink);

            var metrics = await bitly.GetMetrics(linkResponse.Id);
            Assert.IsNotNull(metrics);
        }

        [TestMethod]
        public async Task GetBitlinksByGroupRecent()
        {
            var bitly = new Bitly(_genericAccessToken);
            Assert.IsNotNull(bitly);

            var now = DateTime.Now;
            var testUrl = "https://www.google.ca/?q=" + now.ToShortDateString() + now.ToLongTimeString();
            var linkResponse = await bitly.PostShorten(testUrl);

            Assert.IsNotNull(linkResponse);

            //Bitly won't show links that are very new
            await Task.Delay(TimeSpan.FromSeconds(30));

            var newest = await bitly.GetBitlinksByGroup(createdAfter: now);
            Assert.IsTrue(newest.Links.Any(l => l.LongUrl == testUrl));
        }


        [TestMethod]
        public async Task GetBitlinksByGroupSize()
        {
            var bitly = new Bitly(_genericAccessToken);
            Assert.IsNotNull(bitly);

            var firstPage = await bitly.GetBitlinksByGroup(size: 1);
            Assert.IsTrue(firstPage.Links.Any());
            Assert.IsTrue(firstPage.Pagination.Total > firstPage.Pagination.Size);

            var secondPage = await bitly.GetBitlinksByGroup(size: 1, page: 2);
            Assert.AreEqual(2, secondPage.Pagination.Page);
            Assert.AreNotEqual(firstPage.Links.First().Link, secondPage.Links.First().Link);
        }
    }
}