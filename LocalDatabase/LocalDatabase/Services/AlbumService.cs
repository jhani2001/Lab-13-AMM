using LocalDatabase.DataContext;
using LocalDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocalDatabase.Services
{
    public class AlbumService
    {
        private readonly AppDbContext _context;

        public AlbumService() => _context = App.GetContext();

        public List<Album> Get()
        {
            return _context.Albumes.ToList();
        }

        public Album GetByTitulo(string Titulo)
        {
            return _context.Albumes.Where(x => x.Titulo == Titulo).FirstOrDefault();
        }


        public Album GetByID(int ID)
        {
            return _context.Albumes.Where(x => x.AlbumID == ID).FirstOrDefault();
        }
        public bool Create(Album item)
        {
            try
            {
                _context.Albumes.Add(item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public void Update(Album item, int ID)
        {
            var model = GetByID(ID);
            model.Precio = item.Precio;
            model.Titulo = item.Titulo;
            _context.SaveChanges();
        }
        public void Delete(int ID)
        {
            var model = GetByID(ID);
            _context.Remove(model);
            _context.SaveChanges();
        }
    }
}

