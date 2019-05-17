using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerWebApp.Models
{
    public class MatchViewModel
    {
       
        public SelectList matches;
        public PageList<PredictionData> paging;
        public string matchname;

      
        public async Task<MatchViewModel> getAllMatches(SoccerWebAppContext _context, string matchstring, int? page)
        {

            MatchViewModel ma = new MatchViewModel();

            //Getting list of matches 
           

            ma.matches = new SelectList(await (from n in _context.Match select n.MatchName).Distinct().ToListAsync()); 
            //Getting  Iqueryable list of predictions 
            var listofPredictions = from n in _context.PredictionDatas select n;

       
          

            if (!string.IsNullOrEmpty(matchstring))
            {
                //Getting the list of predictions according to matches
                listofPredictions = listofPredictions.Where(n => n.Match.MatchName == matchstring);

                ma.matchname = matchstring;
            }
         

            //including the prediction relation with tipster and Match
            listofPredictions = listofPredictions.Include(p => p.Match).Include(p => p.Tipster);

           int pagesize = 3;
           ma.paging = await PageList<PredictionData>.CreateAsync(listofPredictions, page ?? 1, pagesize);


            return ma;
        }
    }

    public class PageList<T> : List<T>
    {
        
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }


        public PageList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1); 
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }
        public static async Task<PageList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await  source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new  PageList<T>(items, count , pageIndex, pageSize); 
        }

      

    }
}
