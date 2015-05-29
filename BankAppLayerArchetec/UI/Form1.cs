using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BankAppLayerArchetec.BLL;
using BankAppLayerArchetec.Model;

namespace BankAppLayerArchetec
{
    public partial class CustomerAndAccountInformationUI : Form
    {
        Manager objManager = new Manager();
        Account objAccount = new Account();
        public CustomerAndAccountInformationUI()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            objAccount.AccountNumber = accountNumberEntryTextBox.Text;
            objAccount.CustomerName = CustomerNameTextBox.Text;
            objAccount.OpeningDate = openingDateTextBox.Text;
            objAccount.Email = emailTextBox.Text;

          string output=objManager.Save(objAccount);
          MessageBox.Show(output);

          ShowListView();
            
           
        }

        private void deposit_Click(object sender, EventArgs e)
        {
           
           objAccount.AccountNumber = accountNUmberUpdateTextBox.Text;
            double amount = Convert.ToDouble(amountTextBox.Text);
            double totalBalance = objManager.ManageDeposit(objAccount, amount, "deposit");
            objAccount.balance = totalBalance;
            string output = objManager.Update(objAccount);
            MessageBox.Show(output);
            ShowListView();
        }
           
            
          
          

        private void withdrawTextBox_Click(object sender, EventArgs e)
        {
            objAccount.AccountNumber = accountNUmberUpdateTextBox.Text;
            double amount = Convert.ToDouble(amountTextBox.Text);
            double totalBalance = objManager.ManageDeposit(objAccount, amount, "withdraw");
            objAccount.balance = totalBalance;
            string output = objManager.Update(objAccount);

            MessageBox.Show(output);
            ShowListView();


        }
        public void ShowListView()
        {
            detailShowListView.Items.Clear();
            DataTable tableData = objManager.ShowDetail(objAccount);
            int i = 0;
            while (i < tableData.Rows.Count)
            {
                ListViewItem item = new ListViewItem(tableData.Rows[i][0].ToString());
                item.SubItems.Add(tableData.Rows[i][1].ToString());
                item.SubItems.Add(tableData.Rows[i][2].ToString());
                item.SubItems.Add(tableData.Rows[i][3].ToString());
                item.SubItems.Add(tableData.Rows[i][4].ToString());
                item.SubItems.Add(tableData.Rows[i][5].ToString());
                detailShowListView.Items.Add(item);

                i++;
            }
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            ShowListView();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            detailShowListView.Items.Clear();
            objAccount.AccountNumber = accountNumberSearchTextBox.Text;
           DataTable tableData= objManager.Search(objAccount);
           if (tableData.Rows.Count > 0)
           {
               ListViewItem item = new ListViewItem(tableData.Rows[0][0].ToString());
               item.SubItems.Add(tableData.Rows[0][1].ToString());
               item.SubItems.Add(tableData.Rows[0][2].ToString());
               item.SubItems.Add(tableData.Rows[0][3].ToString());
               item.SubItems.Add(tableData.Rows[0][4].ToString());
               item.SubItems.Add(tableData.Rows[0][5].ToString());
               detailShowListView.Items.Add(item);
           }
           else
           {
               MessageBox.Show("Account number not found");
           }

        }
       
    }
}
