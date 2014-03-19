// Guids.cs
// MUST match guids.h
using System;

namespace BrianSchmitt.LMFTFY
{
    static class GuidList
    {
        public const string guidLMFTFYPkgString = "a443524d-9762-42d0-b152-8c2870b6efe0";
        public const string guidLMFTFYCmdSetString = "48e41467-6e9b-4dcb-9a7a-556015762743";

        public static readonly Guid guidLMFTFYCmdSet = new Guid(guidLMFTFYCmdSetString);
    };
}