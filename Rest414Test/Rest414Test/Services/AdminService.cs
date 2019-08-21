﻿using Rest414Test.Data;
using Rest414Test.Dto;
using Rest414Test.Entity;
using Rest414Test.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest414Test.Services
{
    public class AdminService : UserService
    {
        protected UserItemResource userItemResource;
        protected AdminsResource adminsResource;
        protected LoggedInAdminsResource loggedInAdminsResource;
        protected UserResource userResource;

        public AdminService(IUser adminUser) : base(adminUser)
        {
            userItemResource = new UserItemResource();
            adminsResource = new AdminsResource();
            loggedInAdminsResource = new LoggedInAdminsResource();
            userResource = new UserResource();
            CheckService(!IsAdmin(),
                "Admin " + adminUser.ToString() + "Login Unsuccessful.");
        }

        // Atomic

        public bool IsAdmin()
        {
            // TODO
            return true;
        }

        public ItemTemplate GetUserItem(ItemTemplate itemTemplate, IUser userWithItem)
        {
            RestParameters urlParameters = new RestParameters()
                .AddParameters("token", user.Token);
            RestParameters pathParameters = new RestParameters()
                .AddParameters("index", itemTemplate.Index)
                .AddParameters("name", userWithItem.Name);
            SimpleEntity simpleEntity = userItemResource.HttpGetAsObject(urlParameters, pathParameters);
            //Console.WriteLine("\t***GetUserItem(): simpleEntity = " + simpleEntity);
            // TODO
            //CheckService(!simpleEntity.Equals(true),
            //    "Item " + itemTemplate.ToString() + "was not received.");
            // TODO (new or exist)
            return new ItemTemplate(simpleEntity.content, itemTemplate.Index);
        }

        public string GetAllAdmins()
        {
            RestParameters urlParameters = new RestParameters()
                .AddParameters("token", user.Token);
            //RestParameters pathParameters = new RestParameters()
            SimpleEntity simpleEntity = adminsResource.HttpGetAsObject(urlParameters, null);
            //Console.WriteLine("\t***GetUserItem(): simpleEntity = " + simpleEntity);
            // TODO
            //CheckService(!simpleEntity.Equals(true),
            //    "Item " + itemTemplate.ToString() + "was not received.");
            // TODO (new or exist)
            return simpleEntity.content;
        }

        public string GetLoggedInAdmins()
        {
            RestParameters urlParameters = new RestParameters()
                .AddParameters("token", user.Token);
            //RestParameters pathParameters = new RestParameters()
            SimpleEntity simpleEntity = loggedInAdminsResource.HttpGetAsObject(urlParameters, null);
            //Console.WriteLine("\t***GetUserItem(): simpleEntity = " + simpleEntity);
            // TODO
            //CheckService(!simpleEntity.Equals(true),
            //    "Item " + itemTemplate.ToString() + "was not received.");
            // TODO (new or exist)
            return simpleEntity.content;
        }

        // Business

        public AdminService UpdateTokenlifetime(Lifetime lifetime)
        {
            //Console.WriteLine("lifetime = " + lifetime.Time + "   User = " + user);
            RestParameters bodyParameters = new RestParameters()
                .AddParameters("token", user.Token)
                .AddParameters("time", lifetime.Time);
            SimpleEntity simpleEntity = tokenLifetimeResource.HttpPutAsObject(null, null, bodyParameters);
            // TODO
            CheckService(!simpleEntity.Equals(true),
                "Tokenlifetime " + lifetime.ToString() + "was not Updated.");
            return this;
        }

        public UserService AddAdmin(IUser newAdmin)
        {
            // TODO Develop enum + classes with const in DTO
            RestParameters urlParameters = new RestParameters()
            //RestParameters bodyParameters = new RestParameters()
                .AddParameters("token", user.Token)
                .AddParameters("name", newAdmin.Name)
                .AddParameters("password", newAdmin.Password)
                .AddParameters("rights", "true");
            SimpleEntity simpleEntity = userResource
                .HttpPostAsObject(urlParameters, null, null);
            // TODO
            //CheckService(!simpleEntity.Equals(true),
            //    "Admin " + newAdmin.ToString() + "was not Added.");
            Console.WriteLine("\t***AddAdmin(): simpleEntity = " + simpleEntity);
            return this;
        }

        public UserService RemoveUser(IUser newAdmin)
        {
            // TODO Develop enum + classes with const in DTO
            RestParameters urlParameters = new RestParameters()
            //RestParameters bodyParameters = new RestParameters()
                .AddParameters("token", user.Token)
                .AddParameters("name", newAdmin.Name);
            SimpleEntity simpleEntity = userResource
                .HttpDeleteAsObject(urlParameters, null, null);
            // TODO
            //CheckService(!simpleEntity.Equals(true),
            //    "Admin " + newAdmin.ToString() + "was not Added.");
            Console.WriteLine("\t***AddAdmin(): simpleEntity = " + simpleEntity);
            return this;
        }
    }
}