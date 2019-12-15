using fa19projectgroup16.DAL;
using System;
using System.Linq;

namespace fa19projectgroup16.Utilities
{
    public static class GenerateAccountNumber
    {
        public static Int32 GetNextAccountNumber(AppDbContext _context)
        {
            Int32 intMaxAccountNumber; //the current maximum course number
            Int32 intNextAccountNumber; //the course number for the next class

            if (_context.Accounts.Count() == 0) //there are no courses in the database yet
            {
                intMaxAccountNumber = 10000; //course numbers start at 3001
            }
            else
            {
                intMaxAccountNumber = _context.Accounts.Max(c => c.AccountID); //this is the highest number in the database right now
            }

            //add one to the current max to find the next one
            intNextAccountNumber = intMaxAccountNumber + 1;

            //return the value
            return intNextAccountNumber;
        }

    }
}