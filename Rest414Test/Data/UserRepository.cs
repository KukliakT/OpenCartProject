﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest414Test.Data
{
    public sealed class UserRepository
    {
        private volatile static UserRepository instance;
        private static object lockingObject = new object();

        private UserRepository()
        {
        }

        public static UserRepository Get()
        {
            if (instance == null)
            {
                lock (lockingObject)
                {
                    if (instance == null)
                    {
                        instance = new UserRepository();
                    }
                }
            }
            return instance;
        }

        public IUser Admin()
        {
            return User.Get()
               .SetName("admin")
               .SetPassword("qwerty")
               .Build();
        }

        public IUser AdminForTest()
        {
            return User.Get()
                .SetName("adminToTest")
                .SetPassword("qwerty")
                .Build();
        }

        public IUser AnotherAdmin()
        {
            return User.Get()
                .SetName("anotherAdmin")
                .SetPassword("qwerty")
                .Build();
        }

        public IUser ExistUser()
        {
            return User.Get()
               .SetName("akimatc")
               .SetPassword("qwerty")
               .Build();
        }

        public IUser NewUser()
        {
            return User.Get()
               .SetName("ivan")
               .SetPassword("qwerty")
               .Build();
        }
    }

}