using DAV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAV.Repository
{
    public class DailyVersesRespository
    {
        ApplicationDbContext _context;
        public DailyVersesRespository()
        {
            _context = new ApplicationDbContext();
        }

        public List<DailyVerse> Get()
        {
            return _context.DailyVerses.ToList();
        }

        public DailyVerse Get(int id)
        {
            return _context.DailyVerses.SingleOrDefault(d => d.Id == id);
        }

        public bool Add(DailyVerse verse)
        {
            bool result = false;
            _context.DailyVerses.Add(verse);
            _context.SaveChanges();
            result = true;
            return result;
        }

        public bool Update(DailyVerse verse)
        {
            bool result = false;
            DailyVerse verseInDb = _context.DailyVerses.Single(d => d.Id == verse.Id);
            verseInDb.VerseTitle = verse.VerseTitle;
            verseInDb.VerseDate = verse.VerseDate;
            verseInDb.Verse = verse.Verse;
            _context.SaveChanges();
            result = true;
            return result;
        }
    }
}