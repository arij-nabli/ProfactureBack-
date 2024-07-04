﻿
namespace Pro_FactureAPI.Service.Repertoire;
    using Pro_FactureAPI.Data;
using Pro_FactureAPI.Models;

    public class RepertoireService : IRepertoire
    {
        private readonly ProfactureDb _context;

        public RepertoireService(ProfactureDb context)
        {
            _context = context;
        }

        public IEnumerable<Repertoire> GetAll()
        {
            return _context.Repertoires.ToList();
        }

        public Repertoire Get(int id)
        {
            return _context.Repertoires.Find(id);
        }

        public Repertoire Add(Repertoire repertoire)
        {
            _context.Repertoires.Add(repertoire);
            _context.SaveChanges();
            return repertoire;
        }

        public void Remove(int id)
        {
            var repertoire = _context.Repertoires.Find(id);
            if (repertoire != null)
            {
                _context.Repertoires.Remove(repertoire);
                _context.SaveChanges();
            }
        }

        public bool Update(Repertoire item)
        {
            var existingItem = _context.Repertoires.Find(item.IdRepertoire);
            if (existingItem == null)
            {
                return false;
            }

            _context.Entry(existingItem).CurrentValues.SetValues(item);
            _context.SaveChanges();
            return true;
        }
    }

