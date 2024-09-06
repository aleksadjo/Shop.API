﻿using Shop.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Implementation
{
    public class DefaultActorProvider : IApplicationActorProvider
    {
        public IApplicationActor GetActor()
        {
            return new Actor
            {
                Username = "test",
                Email = "test",
                Id = 0,
                FirstName = "Test",
                LastName = "Test"
            };
        }
    }
}
