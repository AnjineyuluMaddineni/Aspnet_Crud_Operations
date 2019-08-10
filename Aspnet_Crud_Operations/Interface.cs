using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aspnet_Crud_Operations
{
   
    // declaring an interface 
    public interface studentDetails
    {
        // method of interface
        void insertDb();
        void deleteDb();
        void searchDb();
        
    }
    public interface updateStudentDetails : studentDetails
    {
        void updateDb();
    }
    class addStudentDetails : updateStudentDetails
    {
        public void deleteDb()
        {
            throw new NotImplementedException();
        }

        public void insertDb()
        {
            throw new NotImplementedException();
        }

        public void searchDb()
        {
            throw new NotImplementedException();
        }

        public void updateDb()
        {
            throw new NotImplementedException();
        }
    }


}


