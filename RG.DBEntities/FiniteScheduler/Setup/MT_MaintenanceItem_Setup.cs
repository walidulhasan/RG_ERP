using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.FiniteScheduler.Setup
{
   public class MT_MaintenanceItem_Setup:DefaultTableProperties
    {
      public int ID              {get;set;}   
      public string ItemName        {get;set;}
      public int ItemCategoryID  {get;set;} 


    }
}
