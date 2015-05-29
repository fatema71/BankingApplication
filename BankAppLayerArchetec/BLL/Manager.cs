using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankAppLayerArchetec.DAL;
using BankAppLayerArchetec.Model;
using System.Data;

namespace BankAppLayerArchetec.BLL
{
    class Manager
    {
        //Account objAccount = new Account();
        Gateway objGateway = new Gateway();

        public string Save(Account objAccount)
        {
          bool IsExist = objGateway.IsAccountNumberExist(objAccount);
          if (!IsExist)
          {
              if (objAccount.AccountNumber.Length >= 8)
              {
                  int rowAffected = objGateway.Save(objAccount);
                  if (rowAffected > 0)
                  {
                      return " saved successfully";
                  }
                  return "save failed";
              }
              else
              {
                  return "please Enter atleast 8 digit";
              }
          }
          return "Account number is available";
        }
        public DataTable ShowDetail(Account objAccount)
        {
           DataTable tableValue= objGateway.ShowDetail(objAccount);
           return tableValue;
        }
        public double ManageDeposit(Account objAccount, double amount,string state)
        {
            double totalBalance = 0;
            objAccount.balance = objGateway.RetriveAmount(objAccount.AccountNumber);
            if (state == "deposit")
            {
                totalBalance = objAccount.Deposit(amount); 
            }
            else
            {
                totalBalance = objAccount.Withdraw(amount); 
            }
            return totalBalance;
           
        }
        public string Update(Account objAccount)
        {
           int rowAffected= objGateway.Update(objAccount);
            if(rowAffected>0)
            {
                return "Transaction successfull";
            }

            return "Transaction failed";

        }

        public DataTable Search(Account objAccount)
        {
          DataTable tableValue=  objGateway.Search(objAccount);
          return tableValue;
        }

    }
}
