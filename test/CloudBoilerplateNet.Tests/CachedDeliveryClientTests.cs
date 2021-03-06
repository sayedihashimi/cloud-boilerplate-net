﻿using System;
using CloudBoilerplateNet.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Xunit;

namespace CloudBoilerplateNet.Tests
{
    public class CachedDeliveryClientTests
    {

        [Fact]
        public void TestEmptyParams()
        {
            var projectOptions = Options.Create(new ProjectOptions
            {
                KenticoCloudProjectId = "975bf280-fd91-488c-994c-2f04416e5ee3"
            });

            var memoryCacheOptions = Options.Create(new MemoryCacheOptions
            {
                Clock = new TestClock(),
                CompactOnMemoryPressure = true,
                ExpirationScanFrequency = new TimeSpan(0, 0, 5)
            });

            var deliveryClient = new CachedDeliveryClient(projectOptions, new MemoryCache(memoryCacheOptions), 60);

            var result = deliveryClient.GetItemAsync("home");

            Assert.NotNull(result.Result.Item);
        }
    }
}
