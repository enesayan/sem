using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace DataAccessLayer
{
    public class DataAccessBase
    {
        protected string ConnectionString = ConfigurationManager.ConnectionStrings["Sem"].ConnectionString;
    }
}
