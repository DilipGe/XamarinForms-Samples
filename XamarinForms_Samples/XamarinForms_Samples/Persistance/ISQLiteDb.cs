using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace XamarinForms_Samples.Persistance
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
