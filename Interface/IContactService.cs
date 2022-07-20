using ASPNetCoreWebAPiDemo.Models;
using ASPNetCoreWebAPiDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreWebAPiDemo.Interface
{
    public interface IContactService
    {

        List<Contact> GetEmployeesList();


        Contact GetContactDetailsById(int contactID);

        ResponseModel SaveContact(Contact contactModel);


        ResponseModel DeleteContact(int contactId);


    }
}
