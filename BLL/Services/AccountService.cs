using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services
{
    public class AccountService
    {
        //Bước 1: Khai báo biến private
        private readonly AccountRepository _accountRepository;

        //Bước 2: Ctor
        public AccountService()
        {
            _accountRepository = new AccountRepository();
        }

        //Bước 3: Viết các hàm xử lý
        //Get: Lấy thông tin tài khoản
        public Account? GetAccount(string email, string password) => _accountRepository.getAccount(email, password);
    }
}
