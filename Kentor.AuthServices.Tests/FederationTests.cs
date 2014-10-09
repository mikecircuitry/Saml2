﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using FluentAssertions;
using System.IdentityModel.Metadata;

namespace Kentor.AuthServices.Tests
{
    [TestClass]
    public class FederationTests
    {
        [TestMethod]
        public void Federation_LoadSambiTestMetadata()
        {
            // Sambi is the Swedish health care federation. To test that AuthServices
            // handles some real world metadata, the metadadata from Sambi's test
            // environment is used.

            TestLoadMetadata("SambiMetadata.xml");
        }

        private static void TestLoadMetadata(string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                var metadata = (EntitiesDescriptor)MetadataLoader.Load(stream);

                Action a = () => new Federation(metadata, true);

                a.ShouldNotThrow();
            }
        }

        [TestMethod]
        public void Federation_LoadSkolfederationMetadata()
        {
            // Skolfederation is the Swedish national school federation. To test that
            // AuthServices handles some real world metadata, the metdata from the
            // skolfederation federation is used.

            TestLoadMetadata("SkolfederationMetadata.xml");
        }
    }
}
