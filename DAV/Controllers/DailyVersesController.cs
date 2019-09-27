using DAV.Dto;
using DAV.Models;
using DAV.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DAV.Controllers
{
    public class DailyVersesController : Controller
    {
        DailyVersesRespository _repo;
        public DailyVersesController()
        {
            _repo = new DailyVersesRespository();
        }
        // GET: DailyVerses
        public ActionResult Index()
        {
            List<DailyVerseDto> versesDto = new List<DailyVerseDto>();
            ICollection<DailyVerse> verses = _repo.Get();
            foreach (DailyVerse item in verses)
            {
                versesDto.Add(
                    new DailyVerseDto {
                        Id = item.Id,
                        VerseDate = item.VerseDate,
                        VerseTitle = item.VerseTitle,
                        Verse =item.Verse
                    });
            }
            return View(versesDto);
        }

        [HttpGet]
        public ActionResult Add(int id=0)
        {
            if(id >0)
            {
                DailyVerse verse = _repo.Get(id);
                DailyVerseDto verseDto = new DailyVerseDto
                {
                    Id = verse.Id,
                    VerseDate = verse.VerseDate,
                    VerseTitle = verse.VerseTitle,
                    Verse = verse.Verse
                };
                return View(verseDto);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(DailyVerseDto verseDto)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
                DailyVerse verse = new DailyVerse();
                verse.VerseDate = verseDto.VerseDate;
                verse.VerseTitle = verseDto.VerseTitle;
                verse.Verse = verseDto.Verse;
               
                if (verseDto.Id == 0)
                {
                    result= _repo.Add(verse);
                    if (_repo.Add(verse))
                    {
                        ViewBag.Message = "Success";
                        ModelState.Clear();
                    }
                }
                else
                {
                    verse.Id = verseDto.Id;
                    result = _repo.Update(verse);                    
                }
                if (result)
                {
                    ViewBag.Message = "Success";
                }
                else
                {
                    ViewBag.Message = "Unable to save";
                }
            }
            
            
            return View();
        }

    }
}