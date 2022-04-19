using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VtigerIntegration.Models;

namespace VtigerIntegration.Interfaces
{
    public interface IVTigerService
    {
        void Login(string username, string accessKey);
        void Logout();
        VTigerTypeInfo[] Listtypes();
        VTigerObjectType Describe(VTigerType elementType);
        DataTable Describe_DataTable(VTigerType elementType);
        T Retrieve<T>(string id) where T : VTigerEntity;
        T Create<T>(T element) where T : VTigerEntity;
        T Update<T>(T element) where T : VTigerEntity;
        void Delete(string id);
        T FindEntity<T>(string field, string value) where T : VTigerEntity, new();


    }
}
