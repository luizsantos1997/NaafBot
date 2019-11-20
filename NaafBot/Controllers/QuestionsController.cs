using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NaafBot.Models;

namespace NaafBot.Controllers
{
    public class QuestionsController : Controller
    {


        // GET: Questions
        public async Task<List<Question>> Index()
        {
            try
            {
                using (var db = new dbchatruyContext())
                {
                    return await db.Question.ToListAsync();

                };
            }
            catch (Exception)
            {

                return null;
            }
        }

        public static async Task<int> NewQuestion( string text )
        {
            try
            {
                using (var db = new dbchatruyContext())
                {
                    var qest = new Question();
                    qest.DtCriacao = DateTime.Now;
                    qest.TxQuestion = text;
                    db.Add(qest);
                    return await db.SaveChangesAsync();
                };
            }
            catch (Exception)
            {

                return -1;
            }

        }
    }
}
