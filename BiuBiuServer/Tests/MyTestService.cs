﻿using System;
using System.Threading;
using BiuBiuShare.Tests;
using MagicOnion;
using MagicOnion.Server;
using MagicOnion.Server.Authentication;

namespace BiuBiuServer.Tests
{
    public class MyTestService : ServiceBase<IMyTestService>, IMyTestService
    {
        // `UnaryResult<T>` allows the method to be treated as `async` method.
        public async UnaryResult<int> SumAsync(int x, int y)
        {
            Console.WriteLine($"Received:{x}, {y}");
            return x + y;
        }

        [Authorize]
        public async UnaryResult<int> SumAsync1(int x, int y)
        {
            Console.WriteLine($"Received:{x}, {y}");
            return x + y;
        }

        [Authorize(Roles = new[] { "Administrators" })]
        public async UnaryResult<int> SumAsync2(int x, int y)
        {
            Console.WriteLine($"Received:{x}, {y}");
            return x + y;
        }
    }
}