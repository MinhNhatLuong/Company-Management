using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Repositories
{
    public class AccountRepository
    {
        //Bước 1: khai báo biến private
        private readonly CompanyDbContext _dbContext;

        //Bước 2: ctor
        public AccountRepository()
        {
            _dbContext = new CompanyDbContext();
        }

        //Bước 3: viết các hàm lấy dữ liệu
        //Get: lấy thông tin Account
        //hàm nhận vào email và password, trả về account đó nếu có.
        public Account? getAccount(string email, string password)
        {
            //đi xuống database, đi vào bản Accounts lấy ra tài khoản có email là email, password là password
            var account = _dbContext.Accounts
                .FirstOrDefault(x => x.Email == email && x.Password == password);
            return account;
        }
    }
}
