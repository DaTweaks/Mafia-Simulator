using System;
using System.Collections.Generic;
using System.IO;

namespace MafiaSimulator.Data
{
    public abstract class DataBaseHolder
    {
        public virtual void UpdateTable() { }

        public abstract void UpdateData(int topDisplayed = 0);
        
        public abstract void Load(string azureUserId, string azurePassword, string dataBase, string assignedTable);
    }
}