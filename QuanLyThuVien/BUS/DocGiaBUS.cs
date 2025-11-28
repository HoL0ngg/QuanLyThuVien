using QuanLyThuVien.DAO;
using QuanLyThuVien.DTO;
using QuanLyThuVien.GUI;
using System;
using System.Collections.Generic;
using System.Data;

namespace QuanLyThuVien.BUS
{
    public class DocGiaBUS
    {
        private readonly DocGiaDAO dgDAO = new DocGiaDAO();

        public List<DocGiaDTO> GetAll()
        {
            return dgDAO.GetAll();
        }

        public DocGiaDTO GetById(int maDG)
        {
            return dgDAO.GetById(maDG);
        }

        public bool Create(DocGiaDTO dg)
        {
            if (dg == null)
            {
                throw new ArgumentNullException(nameof(dg));
            }
            return dgDAO.Create(dg);
        }

        public bool Update(DocGiaDTO dg)
        {
            if (dg == null)
            {
                throw new ArgumentNullException(nameof(dg));
            }
            return dgDAO.Update(dg);
        }

        public bool Delete(int maDG)
        {
            if (GetById(maDG) == null)
            {
                throw new Exception("Mã độc giả không hợp lệ");
            }
            return dgDAO.Delete(maDG);
        }
    }
}
