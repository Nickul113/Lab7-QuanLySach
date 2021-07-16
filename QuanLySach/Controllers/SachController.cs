using QuanLySach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuanLySach.Controllers
{
    public class SachController : ApiController
    {
        Sach[] sachs = new Sach[]
        {
            new Sach { Id = 1, Title = "Tôi thấy hoa vàng trên cỏ xanh", AuthorName = "Nguyễn Nhật Ánh",
            Price = 1, Content = "Truyện kể về tuổi thơ..."},

            new Sach { Id = 2, Title = "Pro ASP.NET MVC5", AuthorName = "Adam Freeman", Content =
                "The ASP.NET MVC5 Framework is the latest evolution of Microsoft's ASP.NET web platfrom.", Price = 3.75M},
        };

        public IEnumerable<Sach> GetAll()
        {
            return sachs;
        }

        public IHttpActionResult GetSach(int id)
        {
            var sach = sachs.FirstOrDefault((p) => p.Id == id);
            if(sach == null)
            {
                return NotFound();
            }
            return Ok(sach);
        }

        [HttpDelete]
        public bool DeleleSach(int id)
        {
            DBSachDataContext db = new DBSachDataContext();
            //Lấy sách tồn tại ra
            Sach sach = db.Saches.FirstOrDefault(x => x.Id == id);
            if (sach == null) return false;
            db.Saches.DeleteOnSubmit(sach);
            db.SubmitChanges();
            return true;
        }

    }
}
