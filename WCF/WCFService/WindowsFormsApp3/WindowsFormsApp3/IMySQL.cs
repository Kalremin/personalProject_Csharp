using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace WindowsFormsApp3
{
    [ServiceContract]
    public interface IMySQL
    {
        [OperationContract]
        void Connect();

        [OperationContract]
        void CreateDB();

        [OperationContract]
        void CreateTable();

        [OperationContract]
        void InsertTable(int grade, int cclass, int no, string name, string score);//Create

        [OperationContract]
        DataTable ISelectTable();//Read

        [OperationContract]
        void UpdataTable(DataTable dataTable);//Update

        [OperationContract]
        void DeleteTable(string grade);//Remove
        
    }

}
